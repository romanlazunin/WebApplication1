// site.js
(function (name) {

    var ele = document.getElementById("username");
    ele.innerHTML = name;

    var main = document.getElementById("main");
    main.onmouseenter = function () {
        main.style.backgroundColor = "#888";
    };

    main.onmouseleave = function () {
        main.style.backgroundColor = "";
    };
})("Roman Lazunin");