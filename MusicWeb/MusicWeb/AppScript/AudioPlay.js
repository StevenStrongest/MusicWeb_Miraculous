$(document).ready(function () {


    var songs;
    var song = new Audio();
    var songs2;

    var currentSong;
    var play = document.getElementsByClassName('play');
    var duration = document.getElementById('duration');
    var currentTime = document.getElementById('currentTime');
    var songSlider = document.getElementById('fillBar');
    var currentTime = document.getElementById('currentTime');
    var Control = document.getElementById('controlPlay');
    $('.player_left').hide();
    var flag = false;


    $.ajax({
        url: '/BaiHatController/Index',
        type: 'GET',
        dataType: 'json',
        cache: false,
        success: function (rs) {
            songs = rs;

            window.onload = loadSong;

            function loadSong(rs) {
                song.src = '/MusicDowload/' + rs;
                song.playbackRate = 1;
            }

            let timeupdate = setInterval(updateSongSlider, 1000);

            function updateSongSlider() {
                var c = Math.round(song.currentTime);
                currentTime.textContent = convertTime(c);
                song.addEventListener('timeupdate', function () {
                    var position = song.currentTime / song.duration;
                    fillBar.style.width = position * 100 + '%';
                    if (flag) {
                        if (song.ended) {
                            loadSong(currentSong);
                            playOrPauseSong();
                        }
                    }

                });
            }

            function convertTime(secs) {
                var min = Math.floor(secs / 60);
                var sec = secs % 60;
                min = (min < 10) ? "0" + min : min;
                sec = (sec < 10) ? "0" + sec : sec;
                return (min + ":" + sec);
            }

            function convertTime2(secs) {
                var min = Math.floor(secs / 60);
                var sec = secs % 60;
                min = (min < 10) ? "0" + min : min;
                sec = (sec < 10) ? "0" + sec : sec;
                secFormat = Math.round(sec);
                secFormat = (secFormat < 10) ? "0" + secFormat : secFormat;
                return (min + ":" + secFormat);
            }

            //Hàm show thời gian bài hát
            function showDuration() {
                var d = Math.floor(song.duration);
                //songSlider.setAttribute("max", d);
                duration.textContent = convertTime(d);
            }


            //Hàm Dừng và chơi
            function playOrPauseSong() {
                song.playbackRate = 1;
                if (song.paused) {
                    $('button.jp-play .ms_play_control').attr('style', 'background-position: 981px 0px!important');
                    song.play();
                } else {
                    $('button.jp-play .ms_play_control').attr('style', 'background-position: 941px 0px!important');
                    song.pause();
                }
            }

            //Tua 
            var timeDrag = false;
            $('.jp-seek-bar').mousedown(function (e) {
                timeDrag = true;
                updatebar(e.pageX);
            });

            $(document).mouseup(function (e) {
                if (timeDrag) {
                    timeDrag = false;
                    updatebar(e.pageX);
                }
            });
            $(document).mousemove(function (e) {
                if (timeDrag) {
                    updatebar(e.pageX);
                }
            });


            //Tính toán tua audio
            var updatebar = function (x) {
                var progress = $('.jp-progress');
                var position = x - progress.offset().left;
                var percentage = 100 * position / progress.width();
                if (percentage > 100) {
                    percentage = 100;
                }
                if (percentage < 0) {
                    percentage = 0;
                }

                $('.jp-play-bar').css('width', percentage + '%');
                song.currentTime = percentage;
                var c = Math.round(song.currentTime);
                currentTime.textContent = convertTime(c);
            };

            //Vòng lặp chọn bài hát
            $.each(songs, function (index, values) {
                $('.' + values.Id).click(function () {
                    currentSong = values.Link;
                    $('.player_left').show();
                    $(".jp-now-playing").html("<div class='jp-track-name'><span class='que_img'><img style='width: 50px; height: 50px' src='/Assets/images/ImagesOutSource/ImagesSong/" + values.Anh + "'></span><div class='que_data'>" + values.Ten + " <div class='jp-artist-name'>" + values.TenCaSi + "</div></div></div>");
                    loadSong(values.Link);
                    playOrPauseSong();
                    setTimeout(showDuration, 1000);
                    showDuration();
                  
                    $.ajax({
                        url: "/BaiHatController/UpdateView?id=" + values.Id,
                        type: "GET",
                        dataType: 'json',
                        cache: false,
                        success: function (rs) {

                        },
                        error() {
                            alert('Lỗi');
                        }
                    });
                    Notification('success', 'Bạn đang nghe bài hát: ' + values.Ten);
                });

                function getDuration(src, cb) {
                    var audio = new Audio();
                    $(audio).on("loadedmetadata", function () {
                        cb(audio.duration);
                    });
                    audio.src = src;
                }
                getDuration("/MusicDowload/" + values.Link, function (length) {
                    var timeduration = convertTime2(length);
                    document.getElementById("timeSong_" + values.Id).textContent = timeduration;
                });
            });

            //Stop and Play
            Control.onclick = function () {
                playOrPauseSong();
            }

        },
        error: function () {

        }

    });

    //Load Nhạc cá nhân
    $.ajax({
        url: '/NhacCaNhan/ListNhacCaNhan',
        type: 'GET',
        dataType: 'json',
        cache: false,
        success: function (rs) {
            songs2 = rs;

            window.onload = loadSong;

            function loadSong(rs) {
                song.src = '/MusicDowload/' + rs;
                song.playbackRate = 1;
            }

            let timeupdate = setInterval(updateSongSlider, 1000);

            function updateSongSlider() {
                var c = Math.round(song.currentTime);
                currentTime.textContent = convertTime(c);
                song.addEventListener('timeupdate', function () {
                    var position = song.currentTime / song.duration;
                    fillBar.style.width = position * 100 + '%';
                    if (flag) {
                        if (song.ended) {
                            loadSong(currentSong);
                            playOrPauseSong();
                        }
                    }

                });
            }

            function convertTime(secs) {
                var min = Math.floor(secs / 60);
                var sec = secs % 60;
                min = (min < 10) ? "0" + min : min;
                sec = (sec < 10) ? "0" + sec : sec;
                return (min + ":" + sec);
            }

            function convertTime2(secs) {
                var min = Math.floor(secs / 60);
                var sec = secs % 60;
                min = (min < 10) ? "0" + min : min;
                sec = (sec < 10) ? "0" + sec : sec;
                secFormat = Math.round(sec);
                secFormat = (secFormat < 10) ? "0" + secFormat : secFormat;
                return (min + ":" + secFormat);
            }
            //Hàm show thời gian bài hát
            function showDuration() {
                var d = Math.floor(song.duration);
                //songSlider.setAttribute("max", d);
                duration.textContent = convertTime(d);
            }


            //Hàm Dừng và chơi
            function playOrPauseSong() {
                song.playbackRate = 1;
                if (song.paused) {
                    $('button.jp-play .ms_play_control').attr('style', 'background-position: 981px 0px!important');
                    song.play();
                } else {
                    $('button.jp-play .ms_play_control').attr('style', 'background-position: 941px 0px!important');
                    song.pause();
                }
            }

            //Tua 
            var timeDrag = false;
            $('.jp-seek-bar').mousedown(function (e) {
                timeDrag = true;
                updatebar(e.pageX);
            });

            $(document).mouseup(function (e) {
                if (timeDrag) {
                    timeDrag = false;
                    updatebar(e.pageX);
                }
            });
            $(document).mousemove(function (e) {
                if (timeDrag) {
                    updatebar(e.pageX);
                }
            });


            //Tính toán tua audio
            var updatebar = function (x) {
                var progress = $('.jp-progress');
                var position = x - progress.offset().left;
                var percentage = 100 * position / progress.width();
                if (percentage > 100) {
                    percentage = 100;
                }
                if (percentage < 0) {
                    percentage = 0;
                }

                $('.jp-play-bar').css('width', percentage + '%');
                song.currentTime = percentage;
                var c = Math.round(song.currentTime);
                currentTime.textContent = convertTime(c);
            };

            //Vòng lặp chọn bài hát
            $.each(songs2, function (index, values) {
                $('.cn_' + values.IdNhacCaNhan).click(function () {
                    currentSong = values.LinkNhac;
                    $('.player_left').show();
                    $(".jp-now-playing").html("<div class='jp-track-name'><span class='que_img'><img style='width: 50px; height: 50px' src='/Assets/images/ImagesOutSource/ImagesSong/" + values.AnhBaiHat + "'></span><div class='que_data'>" + values.TenBaiHat + " <div class='jp-artist-name'>" + values.NgheSiThucHien + "</div></div></div>");
                    loadSong(values.LinkNhac);
                    playOrPauseSong();
                    setTimeout(showDuration, 1000);
                    showDuration();
                    Notification('success', 'Bạn đang nghe bài hát: ' + values.TenBaiHat);                    
                });

                function getDuration(src, cb) {
                    var audio = new Audio();
                    $(audio).on("loadedmetadata", function () {
                        cb(audio.duration);
                    });
                    audio.src = src;
                }
                getDuration("/MusicDowload/" + values.LinkNhac, function (length) {
                    var timeduration = convertTime2(length);
                    document.getElementById("time_" + values.IdNhacCaNhan).textContent = timeduration;
                });

            });   

            //Stop and Play
                Control.onclick = function () {
                    playOrPauseSong();
                }

        },
        error: function () {

        }

    });

    //Tùy chỉnh âm thanh và các thứ

    $('.knob-wrapper').mousedown(function () {
        $(window).mousemove(function (e) {
            var angle1 = getRotationDegrees($('.knob')),
                volume = angle1 / 270
            song.volume = volume;
        });
        return false;
    }).mouseup(function () {
        $(window).unbind("mousemove");
    });

    //Phát Lại
    var i = 1
    $('.jp-repeat').click(function () {
        if (i == 1) {
            flag = true;
            $('.jp-repeat .ms_play_control').attr('style', 'background-position: 580px 0px!important');
            i = 2;
        } else {
            flag = false;
            $('.jp-repeat .ms_play_control').attr('style', 'background-position: 60px 0px!important');
            i = 1;
        }
    });


    function getRotationDegrees(obj) {
        var matrix = obj.css("-webkit-transform") ||
            obj.css("-moz-transform") ||
            obj.css("-ms-transform") ||
            obj.css("-o-transform") ||
            obj.css("transform");
        if (matrix !== 'none') {
            var values = matrix.split('(')[1].split(')')[0].split(',');
            var a = values[0];
            var b = values[1];
            var angle = Math.round(Math.atan2(b, a) * (180 / Math.PI));
        } else { var angle = 0; }
        return (angle < 0) ? angle + 360 : angle;
    }


})