//百分比设置表格列宽度
function fixWidth(percent) {
    return document.body.clientWidth * percent; //这里你可以自己做调整  
}

//设置导航 仅限_layout衍生并且在home中iframe中使用的子页中调用
function SetNavigateion(level,src,content)
{
    var li = parent.$('#navigation li').last();
    //alert(level);
    //alert(li.children().length);
    while (li.children().length  > level)
    {
        var span = parent.$('#navigation li span').last();
        span.remove();
    }
    if (level > 1)
    {
        li.append("<span>-><a href='javascript:void(0)' src='" + src + "' onclick='OnclickNavigation(this)'>" + content + "</a></span>");
    }
    else
    {
        li.append("<span><a href='javascript:void(0)' src='" + src + "'  onclick='OnclickNavigation(this)'>" + content + "</a></span>");
    }
}

//从a标签中获取src并将设置到iframe，注意事件的写法
function OnclickNavigation(obj)
{
    //alert($(obj).attr("src"));
    SetIframe($(obj).attr("src"));
}

function SetIframe(url)
{
    parent.document.getElementById("mainFrame").src = url;
}