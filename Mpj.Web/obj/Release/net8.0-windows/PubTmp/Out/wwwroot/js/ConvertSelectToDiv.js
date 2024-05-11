
function CreateDiv(divName) {
    
    $('div.select-selected.' + divName).remove();
    $('div.select-items.select-hide.' + divName).remove();
     var x, i, j, l, ll, selElmnt, a, b, c;
    /*look for any elements with the class "custom-select":*/
    x = document.getElementsByClassName("custom-select2 " + divName);
    x1 = document.getElementById(divName);
    l = x.length;
    for (i = 0; i < l; i++) {
        selElmnt = x[i].getElementsByTagName("select")[0];
        ll = selElmnt.length;
        //let div = document.createElement("DIV");
        //div.setAttribute("id", "div" + divName)

        /*for each element, create a new DIV that will act as the selected item:*/
        a = document.createElement("DIV");
        // a.setAttribute("data-val", x1.options[i].value)
        a.setAttribute("class", "select-selected " + divName);
        
        a.innerHTML = selElmnt.options[selElmnt.selectedIndex].innerHTML;
      
        x[i].appendChild(a);
        /*for each element, create a new DIV that will contain the option list:*/
        b = document.createElement("DIV");
        b.setAttribute("class", "select-items select-hide " + divName);
        for (j = 0; j < ll; j++) {
            /*for each option in the original select element,
            create a new DIV that will act as an option item:*/
            c = document.createElement("DIV");
            c.setAttribute("data-val", x1.options[j].value)
            if (x1.options[j].selected)
                c.setAttribute("class", "same-as-selected " + divName);
            // alert(selElmnt.innerHTML)
            //for (i = 0; i < l1; i++) {
            // if (selElmnt.options[i].innerHTML == x.innerHTML) {
            //s.selectedIndex = i;
            //h.innerHTML = this.innerHTML;
            //y = this.parentNode.getElementsByClassName("same-as-selected " + divName);
            //yl = y.length;
            //for (k = 0; k < yl; k++) {
            //    y[k].removeAttribute("class");
            //}
            //this.setAttribute("class", "same-as-selected " + divName);
            //break;
            //}
            //}
            //if (j == 0) {
            //c.setAttribute("class", "same-as-selected " + divName);
            //a.setAttribute("data-val", x1.options[j].value)
            //}

            c.innerHTML = selElmnt.options[j].innerHTML;
            
            c.addEventListener("click", function (e) {
                /*when an item is clicked, update the original select box,
                and the selected item:*/
                var y, i, k, s, h, sl, yl;
                s = this.parentNode.parentNode.getElementsByTagName("select")[0];
                sl = s.length;
                h = this.parentNode.previousSibling;
                for (i = 0; i < sl; i++) {
                    if (s.options[i].innerHTML == this.innerHTML) {
                        s.selectedIndex = i;
                        h.innerHTML = this.innerHTML;
                        y = this.parentNode.getElementsByClassName("same-as-selected " + divName);
                        yl = y.length;
                        for (k = 0; k < yl; k++) {
                            y[k].removeAttribute("class");
                        }
                        this.setAttribute("class", "same-as-selected " + divName);
                        break;
                    }
                }
                h.click();
            });
            b.appendChild(c);
        }
        x[i].appendChild(b);
        //x[i].appendChild(div);
        a.addEventListener("click", function (e) {
            /*when the select box is clicked, close any other select boxes,
            and open/close the current select box:*/
            e.stopPropagation();
            closeAllSelect(this);
            this.nextSibling.classList.toggle("select-hide");
            this.classList.toggle("select-arrow-active");
        });
    }
    //x2 = document.getElementsByClassName("select-items select-hide fReligion");
   // alert($(x2).innerHTML);
    //if (x2.length == 1) {
    //   // y = document.getElementsByClassName("custom-select2 " + "fReligion");
    //    y1 = document.getElementById("fReligion");
    //    for (i = 0; i < y1.length; i++) {
    //        if (y1.options[i].selected) {
    //           //alert(x2[i].innerHTML)
    //        }
    //    }
    //}
    //for (i = 0; i < x2.length; i++) {
    //   alert(x2[i].getElementsByTagName("select")[0]);
    //}
   // if (x2 != undefined)
       // alert($(x2).innerHTML);
    //for (j = 0; j < ll; j++) {
    //    alert()
    //}
}
function closeAllSelect(elmnt) {
    /*a function that will close all select boxes in the document,
    except the current select box:*/
    var x, y, i, xl, yl, arrNo = [];
    x = document.getElementsByClassName("select-items");
    y = document.getElementsByClassName("select-selected");
    xl = x.length;
    yl = y.length;
    for (i = 0; i < yl; i++) {
        if (elmnt == y[i]) {
            arrNo.push(i)
        } else {
            y[i].classList.remove("select-arrow-active");
        }
    }
    for (i = 0; i < xl; i++) {
        if (arrNo.indexOf(i)) {
            x[i].classList.add("select-hide");
        }
    }
}
/*if the user clicks anywhere outside the select box,
then close all select boxes:*/
document.addEventListener("click", closeAllSelect);