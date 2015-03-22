var lastAnchor = '';


function getURLParameter(name) {
  return decodeURIComponent((new RegExp('[?|&]' + name + '=' + '([^&;]+?)(&|#|;|$)').exec(location.search)||[,""])[1].replace(/\+/g, '%20'))||null
}

function toggleKeyValues() {
	if (document.getElementById("toggleKeyValues").value == "Skjul") {
		css('ul#logfileinfo', 'display', 'none');
		toggleButton("toggleKeyValues", "Vis", "Vis n�glev�rdier");
	} else if (document.getElementById("toggleKeyValues").value == "Vis") {
		var headerHeight = getHeaderHeight();
		document.getElementById("logfileinfo").style.top = headerHeight + "px";
		css('ul#logfileinfo', 'display', 'Block');
		setKeyValuesCenter();
		toggleButton("toggleKeyValues", "Skjul", "Skjul n�glev�rdier");
	}
}

(function(d, g) {
	d[g] || (d[g] = function(g) {
		return this.querySelectorAll("." + g)
	}, Element.prototype[g] = d[g])
})(document, "getElementsByClassName");


function css(selector, property, value) {
	for (var i = 0; i < document.styleSheets.length; i++) { //Loop through all styles
		try {
			document.styleSheets[i].insertRule(selector + ' {' + property + ':' + value + '}', document.styleSheets[i].cssRules.length);
		} catch (err) {
			try {
				document.styleSheets[i].addRule(selector, property + ':' + value);
			} catch (err) {}
		} //IE 
	}
}

function toggleButton(buttonId, Value, Text) {
	document.getElementById(buttonId).value = Value;
	document.getElementById(buttonId).innerHTML = Text;
}

function toggleLogElements(divElement, buttonId, logElement) {
	if (document.getElementById(buttonId).value == "Skjul") {
		css(divElement, 'display', 'none');
		toggleButton(buttonId, "Vis", "Vis " + logElement)
	} else if (document.getElementById(buttonId).value == "Vis") {
		css(divElement, 'display', 'Block');
		toggleButton(buttonId, "Skjul", "Skjul " + logElement);
	}
	goToLastAnchor();
}

function loadKeyValueList() {
	var logFileInfoList = document.getElementById("logfileinfo");
	var keyValueList = document.getElementsByClassName("keyvalue");
	for (var i = 0; i < keyValueList.length; i++) {
		var logFileInfoListItem = document.createElement("li");
		var keyItem = document.createElement("b");
		var valueItem = document.createElement("em");
		var key = keyValueList[i].children[0].innerHTML;
		var value = keyValueList[i].children[1].innerHTML;
		var keyItemText = document.createTextNode(key + ": ");
        
		var valueItemText = document.createTextNode(value);

		if ( (value.indexOf("http") == 0) || (value.indexOf("td://") == 0 )) {

			var link = document.createElement('a');
			link.setAttribute('href', value);
			link.textContent = value;
			var valueItemText = link;
		}
		keyItem.appendChild(keyItemText);
		valueItem.appendChild(valueItemText);
		logFileInfoListItem.appendChild(keyItem);
		logFileInfoListItem.appendChild(valueItem);
		logFileInfoList.appendChild(logFileInfoListItem);
	}
	initButtons();
	updateHeaderWithStatus();
}

function displayAllElements(blockOrNone) {
	//css('.pass', 'display', blockOrNone);  
	//css('.fail', 'display', blockOrNone);   
	css('.error', 'display', blockOrNone);
	css('.warn', 'display', blockOrNone);
	css('.info', 'display', blockOrNone);
	css('.debug', 'display', blockOrNone);
	css('.trace', 'display', blockOrNone);
	css('.internal', 'display', blockOrNone);
}

function toggleAll() {
	var buttonId = "toggleAllBtn";
	if (document.getElementById(buttonId).value == "Skjul") {
		displayAllElements('none');
		toggleButton(buttonId, "Vis", "Vis Alt");
		//toggleButton("passBtn", "Vis", "Vis Pass") 
		//toggleButton("failBtn", "Vis", "Vis Fail") 
		toggleButton("errorBtn", "Vis", "Vis Error");
		toggleButton("warnBtn", "Vis", "Vis Warn");
		toggleButton("infoBtn", "Vis", "Vis Info");
		toggleButton("debugBtn", "Vis", "Vis Debug");
		toggleButton("traceBtn", "Vis", "Vis Trace");
		toggleButton("internalBtn", "Vis", "Vis Internal");
	} else if (document.getElementById(buttonId).value == "Vis") {
		displayAllElements('block')
		toggleButton(buttonId, "Skjul", "Skjul Alt");
		toggleButton("passBtn", "Skjul", "Skjul Pass");
		toggleButton("failBtn", "Skjul", "Skjul Fail");
		toggleButton("errorBtn", "Skjul", "Skjul Error");
		toggleButton("warnBtn", "Skjul", "Skjul Warn");
		toggleButton("infoBtn", "Skjul", "Skjul Info");
		toggleButton("debugBtn", "Skjul", "Skjul Debug");
		toggleButton("traceBtn", "Skjul", "Skjul Trace");
		toggleButton("internalBtn", "Skjul", "Skjul Internal");
	}
}

function toggleIndent() {
	var buttonId = "toggleIndent";
	if (document.getElementById(buttonId).value == "Skjul") {
		toggleButton(buttonId, "Vis", "Vis Dybde");
		css('div.pad', 'display', 'none');
	} else if(document.getElementById(buttonId).value == "Vis") {
		toggleButton(buttonId, "Skjul", "Skjul Dybde");
		css('div.pad', 'display', 'Block');
	}
}

function getHeaderHeight() {
	var headerHeight = document.getElementById('header').clientHeight;
	return headerHeight = headerHeight;
}


function pushDownLogElements() {
	var headerHeight = getHeaderHeight();
	headerHeight = headerHeight + 5;
	document.getElementById("logfileelements").style.marginTop= headerHeight + "px";	
}

function setKeyValuesCenter() {
	var widthOfHeader = document.getElementById('header').clientWidth;
	var widthOfKeyValues = document.getElementById('logfileinfo').clientWidth;
	
	var marginLeftKeyValues = (widthOfHeader - widthOfKeyValues) / 2;
	
	document.getElementById("logfileinfo").style.marginLeft= marginLeftKeyValues + "px";
}

function showImage(image) {
	var url=image.getAttribute('src');
	window.open(url,'Image','resizable=1');
}

function initLogFile() {
	loadKeyValueList();
	pushDownLogElements();
}

function addLastAnchor() {
	window.location.hash = lastAnchor;
}

function goToLastAnchor() {
	
	if (lastAnchor.length > 0) {

		document.getElementById(lastAnchor).scrollIntoView()
		var scrollPositionArray = getScrollingPosition();
		var newScrollPosition = scrollPositionArray[1]  + getHeaderHeight();
		window.scrollTo(0, newScrollPosition);
	
	}
}

function sa(anchorName) {
	lastAnchor = (anchorName) 
}

function getScrollingPosition() {      
	
	var position = [0,0];
      
	if (typeof window.pageYOffset != 'undefined'){
      
		position = [window.pageXOffset,window.pageYOffset];
      
	} else if (typeof document.documentElement.scrollTop != 'undefined' && document.documentElement.scrollTop > 0) { 
     
		position = [document.documentElement.scrollLeft, document.documentElement.scrollTop];

	} else if (typeof document.body.scrollTop != 'undefined'){
      
		position = [document.body.scrollLeft, document.body.scrollTop];
      
	}
      
	return position;

}

function hideButtonByDisplayCount(buttonSelector, displayCount) {
    if (displayCount == 0) {
        document.getElementById(buttonSelector).disabled = true;
    }
}

function updateHeaderWithStatus() {
    var statusText = document.getElementById('runstatus').innerHTML;
    var currentGenereatedBy = document.getElementById('generatedbyptf').innerHTML;
    document.getElementById('generatedbyptf').innerHTML = statusText + " - " + currentGenereatedBy;
}

function initButtons() {
    if (getURLParameter("hidebuttons") == "1") {
        css('div#buttons', 'display', 'none');
    } else {
        css('siv#buttons', 'display', 'block');
    }
    hideButtonByDisplayCount("passBtn", PassCount);
    hideButtonByDisplayCount("failBtn", FailCount);
    hideButtonByDisplayCount("errorBtn", ErrorCount);
    hideButtonByDisplayCount("warnBtn", WarnCount);
    hideButtonByDisplayCount("infoBtn", InfoCount);
    hideButtonByDisplayCount("debugBtn", DebugCount);
    hideButtonByDisplayCount("traceBtn", TraceCount);
    hideButtonByDisplayCount("internalBtn", InternalCount);
}