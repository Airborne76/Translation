function translate(translatedTo) {
    var ele = $(".innerTranslate");
    for (var n = 0; n < ele.length; n++) {
        var text = ele[n].innerHTML;
        ele[n].innerHTML = getText(text, JSONtext, translatedTo);
    }
    ele = $(".valueTranslate");
    for (var t = 0; t < ele.length; t++) {
        var text = ele[t].value;
        ele[t].value = getText(text, JSONtext, translatedTo);
    }
}
function getText(keywd, json, language) {
    for (var m = 0; m < json.length; m++) {
        if (json[m].key == keywd) {
            return json[m][language];
        }
    }
}
