window.onresize=ShowAdDiv;
 
	
 function FloatTopDivRight()
	{
		startX = (document.body.clientWidth - 120), startY = 110;
		var d = document;
		
		function ml(id)
		{
			var el=d.getElementById?d.getElementById(id):d.all?d.all[id]:d.layers[id];
			el.sP=function(x,y){this.style.Right=x;this.style.top=y;};
			el.x = startX;
			el.y = startY;
			return el;
		}
		
		window.stayTopRight=function()
		{
			if (document.documentElement && document.documentElement.scrollTop)
				var pY =  document.documentElement.scrollTop;
			else if (document.body)
				var pY =  document.body.scrollTop;
				
			if (document.body.scrollTop > 71)
			{
				startY = 3
			}
			else 
			{
				startY = 110
			};
			
			ftlObjRight.y += (pY + startY - ftlObjRight.y) / (66 - 60);
			ftlObjRight.sP(ftlObjRight.x, ftlObjRight.y);
			setTimeout("stayTopRight()", 20);
		}
		
		ftlObjRight = ml("divAdRight");
		stayTopRight();
	}	
	function ShowAdDiv()
	{		
		var objAdDivRight = document.getElementById("divAdRight");
		if (document.body.clientWidth < 780)
		{		    
		    objAdDivRight.style.display = "none";
		}
		else
		{			
			objAdDivRight.style.display = "block";
			FloatTopDivRight();
		}
	}
	
	ShowAdDiv();