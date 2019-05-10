function getCommentNumber(surl) {
    var url = 'https://graph.facebook.com/' + surl;
    //alert(url);
    $.ajax({
        url: url,
        dataType: 'jsonp',
        success: function (data) {
            //  alert("comments: " + data.share.comment_count);
            return data.share.comment_count;
        }
    });
    return 0;
}
function changBg(surl) {
    $('div.banner-agile-2').css('background', 'url('+surl+')  no-repeat center');
    $('div.banner-agile-2').css('background-size', 'cover');
    $('div.banner-agile-2').css('-webkit-background-size', 'cover');
    $('div.banner-agile-2').css('-moz-background-size', 'cover');
    $('div.banner-agile-2').css('-o-background-size', 'cover');
    $('div.banner-agile-2').css('-ms-background-size', 'cover');
    $('div.banner-agile-2').css('background-attachment', 'fixed');
    $('div.banner-agile-2').css('min-height', '260px');

}