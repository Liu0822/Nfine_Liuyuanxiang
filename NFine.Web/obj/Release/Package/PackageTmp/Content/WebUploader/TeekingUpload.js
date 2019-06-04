﻿(function (window) {
    // 如果需要在模态框中使用webuploader，那么必须先调用prepareModal，
    // 再调用initWebUploader。这样可以解决模态框中使用webuploader出现的BUG。
    // 例如prepareModal('#addProductModal')
    this.prepareModal = function (modalId) {
        var _$modal = $(modalId);
        _$modal.css('display', 'block');
        _$modal.addClass("webuploader-element-invisible");
        _$modal.on('show.bs.modal', function () {
            _$modal.removeClass("webuploader-element-invisible");
        });
    }
    var BASE_URL = '~/Scripts/webuploader';
    this.initWebUploader = function (webUploaderId, filePickerId, fileAddId, uploadUrl, deleteUrl, getUrl, paramter) {
        var $ = jQuery,    // just in case. Make sure it's not an other libaray.  

            $wrap = $('#uploader'),

            // 图片容器  
            $queue = $('<ul class="filelist"></ul>')
                .appendTo($wrap.find('.queueList')),

            // 状态栏，包括进度和控制按钮  
            $statusBar = $wrap.find('.statusBar'),

            // 文件总体选择信息。  
            //$info = $statusBar.find('.info'),
            // 文件放大查看信息。  
            //  $BigImg = $statusBar.find('.bigimgview'),  
            // 文件放大查看信息。  
            // $DeleteImg = $statusBar.find('.deleteimg'),  
            // 上传按钮  
            $upload = $wrap.find('.uploadBtn'),

            // 没选择文件之前的内容。  
            $placeHolder = $wrap.find('.placeholder'),

            // 总体进度条  
            //$progress = $statusBar.find('.progress').hide(),

            // 添加的文件数量  
            fileCount = 0,

            // 添加的文件总大小  
            fileSize = 0,

            // 优化retina, 在retina下这个值是2  
            ratio = window.devicePixelRatio || 1,

            // 缩略图大小  
            thumbnailWidth = 110 * ratio,
            thumbnailHeight = 110 * ratio,

            // 可能有pedding, ready, uploading, confirm, done.  
            state = 'pedding',

            // 所有文件的进度信息，key为file id  
            percentages = {},

            supportTransition = (function () {
                var s = document.createElement('p').style,
                    r = 'transition' in s ||
                        'WebkitTransition' in s ||
                        'MozTransition' in s ||
                        'msTransition' in s ||
                        'OTransition' in s;
                s = null;
                return r;
            })(),
            // WebUploader实例  
            uploader;

        if (!WebUploader.Uploader.support()) {
            alert('Web Uploader 不支持您的浏览器！如果你使用的是IE浏览器，请尝试升级 flash 播放器');
            throw new Error('WebUploader does not support the browser you are using.');
        }
        // 实例化  
        uploader = WebUploader.create({
            pick: {
                id: '#filePicker',//绑定选择文件按钮，前台照搬，这里就不用管了  
                label: '点击选择图片'
            },
            dnd: '#uploader .queueList',
            paste: document.body,

            accept: {
                title: 'Images',
                extensions: 'gif,jpg,jpeg,bmp,png,doc,docx,xls',
                mimeTypes: 'image/gif,image/jpg,image/jpeg,image/bmp,image/png'
            },
            //<span style="color:#FF0000;">这里可以自定义参数，比如我自定义的orderNo</span>  
            //form
            //: {    
            //    orderNo: ""    
            //},    
            // swf文件路径  
            swf: BASE_URL + '/Uploader.swf',
            disableGlobalDnd: true,
            chunked: true,
            server: uploadUrl,
            deleteServer: deleteUrl,
            fileNumLimit: 10,
            fileSizeLimit: 20 * 1024 * 1024,    // 200 M  
            fileSingleSizeLimit: 2 * 1024 * 1024    // 50 M  
        });
        // 添加“添加文件”的按钮，  
        uploader.addButton({
            id: '#filePicker2',
            label: '继续添加'
        });
        //<span style="color:#FF0000;">文件上传前封装自定义参数</span>  
        uploader.on('uploadBeforeSend', function (block, data) {
            // block为分块数据。    
            // file为分块对应的file对象。    
            var file = block.file;

            // <span style="color:#FF0000;">修改data可以控制发送哪些携带数据</span>   
            data.orderNo = "TB201010";
        });
        ////////************************编辑回看，并添加删除功能********************//////
        var getFileBlob = function (url, cb) {
            var xhr = new XMLHttpRequest();
            xhr.open("GET", url);
            xhr.responseType = "blob";
            xhr.addEventListener('load', function () {
                cb(xhr.response);
            });
            xhr.send();
        };
        var blobToFile = function (blob, name) {
            blob.lastModifiedDate = new Date();
            blob.name = name;
            return blob;
        };
        function getFileObject(filePathOrUrl, cb) {
            getFileBlob(filePathOrUrl, function (blob) {
                cb(blobToFile(blob, filePathOrUrl.split('/')[filePathOrUrl.split('/').length - 1]));
            });
        }
        var updateBtnInfo = function (file) {
            $("#" + file.id).attr("data-img", file.name);
            var $btns = null;
            $('#' + file.id).addClass('upload-state-done');
            $('#' + file.id).find("img").parent().append('<a  href="' + file.name + '" target="_blank"></a>')             
            $('#' + file.id).find(".imgWrap").find("a").append($('#' + file.id).find(".imgWrap").find("img"));
            $('#' + file.id).find(".imgWrap").after('<span class="success"></span>')
            $btns = $('<div class="file-panel">' +
                '<span class="cancel">删除</span>' +
                '</div>');
            $btns.on('click', 'span', function () {
                var index = $(this).index(),
                    deg;
                switch (index) {
                    case 0:
                        paramter.photoName = file.name;// { "photoName":file.name}
                        $.post(deleteUrl, paramter, function (rlt) {
                            if (rlt) {
                                uploader.removeFile(file);
                            } else {
                                console.log("删除失败");
                            }
                        })
                        return;
                }
            });
            $('#' + file.id).append($btns);
            $('#' + file.id).on('mouseenter', function () {
                $btns.stop().animate({ height: 30 });
            });
            $('#' + file.id).on('mouseleave', function () {
                $btns.stop().animate({ height: 0 });
            });
        }
        var getFiles = function (url, data) {
            $.getJSON(url, data, function (result) {
               
                var flagCount = 0;
                VoucherImg = "";
                for (var j in result) {
                    if (flagCount==0)
                    {
                        VoucherImg = result[j];
                        flagCount++
                    }
                    else
                        break;
                }
              
                if (VoucherImg != "" && VoucherImg != null) {
                    var picList = VoucherImg.split(',');
                    for (var i = 0; i < picList.length; i++) {
                        var item = picList[i].replace("~", "");
                        getFileObject(item, function (fileObject) {
                            var wuFile = new WebUploader.Lib.File(WebUploader.guid('rt_'), fileObject);
                            var file = new WebUploader.File(wuFile);
                            addFile(file, 0)
                            updateBtnInfo(file, data);
                            fileCount++;
                            fileSize += file.size;
                            if (fileCount === 1) {
                                $placeHolder.addClass('element-invisible');
                                $statusBar.show();
                            }
                            //addFile(file, uploader[i], $queue);
                            setState('ready', uploader[i], $placeHolder, $queue, $statusBar, filePicker2);
                            //updateStatus('ready', fileCount, fileSize);
                        })
                    }
                }
            });
        };
        getFiles(getUrl, paramter);

        ///////////////////*****************************/////////////////////////////////


        ///////////////////*****************************/////////////////////////////////
        // 当有文件添加进来时执行，负责view的创建  
        function addFile(file, type) {
            debugger;
            var btn = (type == 1 ? '<div class="file-panel">' +
                '<span class="cancel">删除</span>' +
                '<span class="rotateRight">向右旋转</span>' +
                '<span class="rotateLeft">向左旋转</span></div>' :
                '<div class="file-panel"><span class="cancel" on>删除</span></div>');

           //修改标记一下5/28
            var $li = $('<li id="' + file.id + '">' +
                '<p class="title">' + file.name + '</p>' +
                '<p style="cursor:pointer" class="imgWrap"></p>' +
                '<p class="progress"><span></span></p>' +
                '</li>'),
                $btns = $(btn).appendTo($li),
                $prgress = $li.find('p.progress span'),
                $wrap = $li.find('p.imgWrap'),
                //$info = $('<p class="error"></p>'),

                showError = function (code) {
                    switch (code) {
                        case 'exceed_size':
                            text = '文件大小超出';
                            break;

                        case 'interrupt':
                            text = '上传暂停';
                            break;

                        default:
                            text = '上传失败，请重试';
                            break;
                    }

                    //$info.text(text).appendTo($li);
                };

            if (file.getStatus() === 'invalid') {
                showError(file.statusText);
            } else {
                // todo lazyload  
                $wrap.text('预览中');
                uploader.makeThumb(file, function (error, src) {
                    if (error) {
                        $wrap.text('不能预览');
                        return;
                    }

                    var img = $('<img src="' + src + '">');
                    $wrap.empty().append(img);
                }, thumbnailWidth, thumbnailHeight);

                percentages[file.id] = [file.size, 0];
                file.rotation = 0;
            }

            file.on('statuschange', function (cur, prev) {
                if (prev === 'progress') {
                    $prgress.hide().width(0);
                } else if (prev === 'queued') {
                    $li.off('mouseenter mouseleave');
                    $btns.remove();
                }

                // 成功  
                if (cur === 'error' || cur === 'invalid') {
                    // console.log(file.statusText);  
                    showError(file.statusText);
                    percentages[file.id][1] = 1;
                } else if (cur === 'interrupt') {
                    showError('interrupt');
                } else if (cur === 'queued') {
                    percentages[file.id][1] = 0;
                } else if (cur === 'progress') {
                    //$info.remove();
                    $prgress.css('display', 'block');
                } else if (cur === 'complete') {
                    $li.append('<span class="success"></span>');
                }

                $li.removeClass('state-' + prev).addClass('state-' + cur);
            });

            $li.on('mouseenter', function () {
                $btns.stop().animate({ height: 30 });
            });

            $li.on('mouseleave', function () {
                $btns.stop().animate({ height: 0 });
            });

            $btns.on('click', 'span', function () {
                var index = $(this).index(),
                    deg;

                switch (index) {
                    case 0:
                        uploader.removeFile(file);
                        return;
                    case 1:
                        file.rotation += 90;
                        break;
                    case 2:
                        file.rotation -= 90;
                        break;
                }

                if (supportTransition) {
                    deg = 'rotate(' + file.rotation + 'deg)';
                    $wrap.css({
                        '-webkit-transform': deg,
                        '-mos-transform': deg,
                        '-o-transform': deg,
                        'transform': deg
                    });
                } else {
                    $wrap.css('filter', 'progid:DXImageTransform.Microsoft.BasicImage(rotation=' + (~~((file.rotation / 90) % 4 + 4) % 4) + ')');
                    // use jquery animate to rotation  
                    // $({  
                    //     rotation: rotation  
                    // }).animate({  
                    //     rotation: file.rotation  
                    // }, {  
                    //     easing: 'linear',  
                    //     step: function( now ) {  
                    //         now = now * Math.PI / 180;  

                    //         var cos = Math.cos( now ),  
                    //             sin = Math.sin( now );  

                    //         $wrap.css( 'filter', "progid:DXImageTransform.Microsoft.Matrix(M11=" + cos + ",M12=" + (-sin) + ",M21=" + sin + ",M22=" + cos + ",SizingMethod='auto expand')");  
                    //     }  
                    // });  
                }

            });
            $li.appendTo($queue);
        }
        // 负责view的销毁  
        function removeFile(file) {
            var $li = $('#' + file.id);

            delete percentages[file.id];
            //updateTotalProgress();
            $li.off().find('.file-panel').off().end().remove();
        }
        function setState(val) {
            var file, stats;

            if (val === state) {
                return;
            }
            $upload.removeClass('state-' + state);
            $upload.addClass('state-' + val);
            state = val;
            switch (state) {
                case 'pedding':
                    $placeHolder.removeClass('element-invisible');
                    $queue.parent().removeClass('filled');
                    $queue.hide();
                    $statusBar.addClass('element-invisible');
                    uploader.refresh();
                    break;

                case 'ready':
                    $placeHolder.addClass('element-invisible');
                    $('#filePicker2').removeClass('element-invisible');
                    $queue.parent().addClass('filled');
                    $queue.show();
                    $statusBar.removeClass('element-invisible');
                    uploader.refresh();
                    break;

                case 'uploading':
                    //$('#filePicker2').addClass('element-invisible');
                    //$progress.show();
                    //$upload.text('暂停上传');
                    break;

                case 'paused':
                    //$progress.show();
                    $upload.text('继续上传');
                    break;

                case 'confirm':
                    //$progress.hide();
                    $upload.text('开始上传').addClass('disabled');

                    stats = uploader.getStats();
                    if (stats.successNum && !stats.uploadFailNum) {
                        setState('finish');
                        return;
                    }
                    break;
                case 'finish':
                    stats = uploader.getStats();
                    console.log("状态", stats)
                    if (stats.successNum) {
                        // alert('上传成功');  
                    } else {
                        // 没有成功的图片，重设  
                        state = 'done';
                        location.reload();
                    }
                    break;
            }

            //updateStatus();
        }
        uploader.onUploadProgress = function (file, percentage) {
            var $li = $('#' + file.id),
                $percent = $li.find('.progress span');

            $percent.css('width', percentage * 100 + '%');
            percentages[file.id][1] = percentage;
            //updateTotalProgress();
        };
        uploader.onFileQueued = function (file) {
            fileCount++;
            fileSize += file.size;

            //if (fileCount === 1) {
            $placeHolder.addClass('element-invisible');
            $statusBar.show();
            //}
            //判断当上传图片超过六张就不允许上传
            addFile(file, 1);
            setState('ready');
            //updateTotalProgress();
        };
        uploader.onFileDequeued = function (file) {
            fileCount--;
            fileSize -= file.size;

            if (!fileCount) {
                setState('pedding');
            }

            removeFile(file);
            //updateTotalProgress();

        };
        uploader.on('all', function (type) {
            var stats;
            switch (type) {
                case 'uploadFinished':
                    // setState('confirm');  
                    break;

                case 'startUpload':
                    setState('uploading');
                    break;

                case 'stopUpload':
                    setState('paused');
                    break;

            }
        });
        uploader.onError = function (code) {
            // alert('不能上传相同的图片！');  
            alert('Eroor: ' + code);
        };
        $upload.on('click', function () {
            if ($(this).hasClass('disabled')) {
                return false;
            }
            if (state === 'ready') {
                uploader.upload();
                dialogMsg("上传成功！", 1);
            } else if (state === 'paused') {
                uploader.upload();
                //  console.log("上传继续");  
            } else if (state === 'uploading') {
                uploader.stop();
                //console.log("上传停止");  
            }
        });
        $upload.addClass('state-' + state);
        // 文件上传成功，给item添加成功class, 用样式标记上传成功。  
        uploader.on('uploadSuccess', function (file, data) {
            //<span style="color:#FF0000;">文件上传成功后，会出发这个事件，后台返回的参数在data里</span>  
            //filePath是自定义返回的文件保存路径，可以方便前台处理，一般就是图片路径涉及到怎么跟当前这条信息绑定起来       
            $("#" + file.id).attr("data-img", data.filePath);
            var $btns = null;
            if (data.status == 0) {
                //上传成功后，绑定删除事件  
                $('#' + file.id).addClass('upload-state-done');
                $('#' + file.id).find("img").parent().append('<a href="' + data.filePath + '" target="_blank"></a>') //标记一下
                $('#' + file.id).find(".imgWrap").find("a").append($('#' + file.id).find(".imgWrap").find("img"));
                $btns = $('<div class="file-panel">' +
                    '<span class="cancel">删除</span>' +
                    '</div>');
                $btns.on('click', 'span', function () {
                    var index = $(this).index(),
                        deg;
                    //用户点击删除的时候触发  
                    //$(this).parent().parent().remove();  
                    //异步上传文件，可以注释，使用上面一句前台伪删除，保存的时候处理  
                    switch (index) {
                        case 0:
                            paramter.photoName = data.filePath;// { "photoName": data.filePath }
                            $.post(deleteUrl, paramter, function (rlt) {
                                if (rlt) {
                                    uploader.removeFile(file);
                                } else {
                                    console.log("删除失败");
                                }
                            })
                            return;
                    }

                });
                $('#' + file.id).append($btns);
                $('#' + file.id).on('mouseenter', function () {
                    $btns.stop().animate({ height: 30 });
                });

                $('#' + file.id).on('mouseleave', function () {
                    $btns.stop().animate({ height: 0 });
                });
            }
            else if (data.Code == -1) {
                var $li = $('#' + file.id),
                    $error = $li.find('div.error');

                // 避免重复创建  
                if (!$error.length) {
                    $error = $('<div class="error"></div>').appendTo($li);
                }
                $error.text('上传失败');
            }
        });
        // 文件上传失败，显示上传出错。  
        uploader.on('uploadError', function (file) {
            var $li = $('#' + file.id),
                $error = $li.find('div.error');

            // 避免重复创建  
            if (!$error.length) {
                $error = $('<div class="error"></div>').appendTo($li);
            }
            $error.text('上传失败');
        });
        // 完成上传完了，成功或者失败，先删除进度条。  
        uploader.on('uploadComplete', function (file) {
            $('#' + file.id).find('.progress').remove();
        });
    }
    window.CommonWebUploader = this;
})(window);