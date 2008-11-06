 /*
  * Infragistics WebGrid CSOM Script: ig_WebGrid_srt.js
  * Version 7.1.20071.1048
  * Copyright(c) 2001-2006 Infragistics, Inc. All Rights Reserved.
  */

// ig_WebGrid_srt.js
// Infragistics UltraWebGrid Script 
// Copyright (c) 2001-2007 Infragistics, Inc. All Rights Reserved.
function igtbl_sortGrid()
{
	if(this.Rows.Node && this.LoadOnDemand==3)
		this.Rows.sortXml();
	else
		this.Rows.sort();
}

function igtbl_columnCompareRows(row1,row2)
{
	if(!row1.GroupByRow || !row2.GroupByRow)
		return;
	var res=0;
	var v1=row1.Value;
	var v2=row2.Value;
	if(v1!=null || v2!=null)
	{
		if(!row1.Band.Grid.CaseSensitiveSort)
		{
			if(typeof(v1)=="string")
				v1=v1.toLowerCase();
			if(typeof(v2)=="string")
				v2=v2.toLowerCase();
		}
		switch(this.DataType)
		{
			case 8:
			{
				if (ig_csom.IsIE55Plus || ig_csom.IsNetscape6 || (v1 && v1.localeCompare))
				{
					if(v1==null && v2!=null)
						res=-1;
					else if(v1!=null && v2==null)
						res=1;
					else 
						res=v1.localeCompare(v2);
				}

				else
					if(v1==null && v2!=null)
						res=-1;
					else if(v1!=null && v2==null)
						res=1;
					else if(v1<v2)
						res=-1;
					else if(v1>v2)
						res=1;	
				break;
			}
			default:
				if(v1==null && v2!=null)
					res=-1;
				else if(v1!=null && v2==null)
					res=1;
				else if(v1<v2)
					res=-1;
				else if(v1>v2)
					res=1;
		}
		if(this.SortIndicator==2)
			res=-res;
	}
	return res;
}

function igtbl_columnCompareCells(cell1,cell2)
{
	var res=0;
	var v1=cell1.getValue(this.ColumnType==5 || this.WebComboId);
	var v2=cell2.getValue(this.ColumnType==5 || this.WebComboId);
	if(v1!=null || v2!=null)
	{
		if(!cell1.Band.Grid.CaseSensitiveSort)
		{
			if(typeof(v1)=="string")
				v1=v1.toLowerCase();
			if(typeof(v2)=="string")
				v2=v2.toLowerCase();
		}
		switch(this.DataType)
		{
			case 8:
			{
				if (ig_csom.IsIE55Plus || ig_csom.IsNetscape6 || (v1 && v1.localeCompare))
				{
					if(v1==null && v2!=null)
						res=-1;
					else if(v1!=null && v2==null)
						res=1;
					else 
						res=v1.localeCompare(v2);
				}

				else
					if(v1==null && v2!=null)
						res=-1;
					else if(v1!=null && v2==null)
						res=1;
					else if(v1<v2)
						res=-1;
					else if(v1>v2)
						res=1;	
				break;
			}
			default:
				if(v1==null && v2!=null)
					res=-1;
				else if(v1!=null && v2==null)
					res=1;
				else if(v1<v2)
					res=-1;
				else if(v1>v2)
					res=1;
		}
		if(this.SortIndicator==2)
			res=-res;
	}
	return res;
}


function igtbl_compare(av1, av2, caseSens, sort)
{
	return igtbl_compareRows(av1,av2, sort, caseSens);
}


function igtbl_compareRows(av1,av2, columns, caseSens)
{
	var res=0;
	for(var i=0;i<columns.length && res==0;i++)
	{
		var v1=av1[i+1];
		var v2=av2[i+1];
		if(v1!=null || v2!=null)
		{
			var t1=typeof(v1);
			var t2=typeof(v2);
			if(!caseSens)
			{
				if(t1=="string")
					v1=v1.toLowerCase();
				if(t2=="string")
					v2=v2.toLowerCase();
			}
			if(t1=="string" && t2=="string")
			{
				if (ig_csom.IsIE55Plus || ig_csom.IsNetscape6 || (v1 && v1.localeCompare))
				{
					if(v1==null && v2!=null)
						res=-1;
					else if(v1!=null && v2==null)
						res=1;
					else
						res=v1.localeCompare(v2);
				}
				else
					if(v1==null && v2!=null)
						res=-1;
					else if(v1!=null && v2==null)
						res=1;
					else if(v1<v2)
						res=-1;
					else if(v1>v2)
						res=1;
			}
			else
			{
				if(v1==null && v2!=null)
					res=-1;
				else if(v1!=null && v2==null)
					res=1;
				else if(v1<v2)
					res=-1;
				else if(v1>v2)
					res=1;
			}
			
			if(columns[i] == 2)
			{
				res=-res;
			}
		}
	}
	return res;
}

function igtbl_quickSort(cln,array,left,right)
{
	var i,j,comp,temp;
	i=left;
	j=right;
	comp=cln.getRow(array[Math.floor((left+right)/2)]);
	do
	{
		while(cln.getRow(array[i]).compare(comp)<0 && i<right)
			i++;
		while(cln.getRow(array[j]).compare(comp)>0 && j>left)
			j--;
		if(i<=j)
		{
			temp=array[i];
			array[i]=array[j];
			array[j]=temp;
			i++;
			j--;
		} 
	}
	while(i<=j);
	if(left<j)
		igtbl_quickSort(cln,array,left,j);
	if(i<right)
		igtbl_quickSort(cln,array,i,right); 
}

function igtbl_quickSort1(cln,array,colInfo,left,right)
{
	var i,j,comp,temp;
	i=left;
	j=right;
	comp=array[Math.floor((left+right)/2)];
	var caseSense=cln.Grid.CaseSensitiveSort;
	do
	{
		while(igtbl_compare(array[i],comp,caseSense,colInfo)<0 && i<right)
			i++;

		while(igtbl_compare(array[j],comp,caseSense,colInfo)>0 && j>left)
			j--;
		if(i<=j)
		{
			if(i<j)
			{
				temp=array[i];
				array[i]=array[j];
				array[j]=temp;
			}
			i++;
			j--;
		}
	}
	while(i<=j);
	if(left<j)
		igtbl_quickSort1(cln,array,colInfo,left,j);
	if(i<right)
		igtbl_quickSort1(cln,array,colInfo,i,right);
}

function igtbl_bubbleSort(cln,array,colInfo)
{
	var hasSwapped=true;
	var caseSense=cln.Grid.CaseSensitiveSort;
	while(hasSwapped)
	{
		hasSwapped=false;
		for(var i=0;i<array.length-1;i++)
		{
			if(igtbl_compare(array[i],array[i+1],caseSense,colInfo)>0)
			{
				hasSwapped=true;
				var swap=array[i];
				array[i]=array[i+1]
				array[i+1]=swap;
			}
		}
	}
}

function igtbl_insertionSort(cln,array,colInfo)
{
	var caseSense=cln.Grid.CaseSensitiveSort;
	var i=1;
	while(i<array.length)
	{
		var row=array[i];
		var j=i-1;

		while(j>=0 && igtbl_compare(array[j],row,caseSense,colInfo)>0)
		{
			array[j+1]=array[j];
			j--;
		}
		array[j+1]=row;
		i++;
	}
}

function igtbl_binaryTreeNodeCreate()
{
	return {"values":[], "left":null, "right":null};
}

function igtbl_binaryTreeInsert(tree, value, array, colInfo, caseSense)
{
	if(tree.values.length==0)
		tree.values[0]=value;
	else
	{
		var treeRow=tree.values[0];
		var compareResult=igtbl_compare(value,treeRow,caseSense,colInfo);
		if(compareResult==0)
			tree.values[tree.values.length]=value;
		else if(compareResult<0)
			tree.left=igtbl_binaryTreeInsert(tree.left==null?igtbl_binaryTreeNodeCreate():tree.left,value,array,colInfo);
		else
			tree.right=igtbl_binaryTreeInsert(tree.right==null?igtbl_binaryTreeNodeCreate():tree.right,value,array,colInfo);
	}
	return tree;
}

function igtbl_binaryTreeTraverse(tree, array, index)
{
	if(tree.left!=null)
		index=igtbl_binaryTreeTraverse(tree.left,array,index);
	for(var i=0;i<tree.values.length;i++)
	{
		array[index++]=tree.values[i];
		tree.values[i]=null;
	}
	if(tree.right!=null)
		index=igtbl_binaryTreeTraverse(tree.right,array,index);
	return index;
}

function igtbl_binaryTreeSort(cln,array,colInfo)
{
	var caseSense=cln.Grid.CaseSensitiveSort;
	var tree=igtbl_binaryTreeNodeCreate();
	for(var i=0;i<array.length;i++)
		tree=igtbl_binaryTreeInsert(tree,array[i],array,colInfo,caseSense);
	igtbl_binaryTreeTraverse(tree,array,0);
	igtbl_dispose(tree);
}

function igtbl_clctnSort(sortedCols)
{
	if(
		!this.Band.IsGrouped && this.Grid.LoadOnDemand==3)
		return this.sortXml();
	if(!sortedCols)
		sortedCols=this.Band.SortedColumns;
	this.setLastRowId();
	var changed=true;
	var sortArray=new Array(this.length);
	var colInfo=new Array();
	var chkBoxArray=new Array();
	for(var i=0;i<this.length;i++)
		sortArray[i]=[i];
	for(var j=0;j<this.Band.SortedColumns.length;j++)
	{
		var column=igtbl_getColumnById(this.Band.SortedColumns[j]);
		if(column.IsGroupBy)
		{
			if(this.length>0)
			{
				var grCol=igtbl_getColumnById(this.getRow(0).GroupColId);
				if(grCol==column)
				{
					for(var i=0;i<this.length;i++)
						sortArray[i][j+1]=this.getRow(i).Value;
					colInfo[j]=column.SortIndicator;
				}
			}
		}
		else
		{
		    
		    if(column.ColumnType==5)
		    {
		        for(var i=0;i<this.length;i++)
			    {
				    var srtCol = this.getRow(i).getCellByColumn(column);
				    if (srtCol)	sortArray[i][j+1]=srtCol.getValue(true);
			    }
		    }
		    else
		    {
   			    for(var i=0;i<this.length;i++)
			    {
				    var srtCol = this.getRow(i).getCellByColumn(column);
				    if (srtCol)	sortArray[i][j+1]=srtCol.getValue();
			    }
		    }
			
		    colInfo[j]=column.SortIndicator;
		}
	}
	for(i=0;i<this.Band.Columns.length;i++)
	{
		var col=this.Band.Columns[i];
		if(col.hasCells() && col.ColumnType==3)
			chkBoxArray[chkBoxArray.length]=i;
	}
	if(sortedCols.length>0 && this.length>0)
	{
		var firstSortCol=igtbl_getColumnById(sortedCols[0]);
		var sortAlg=firstSortCol.getSortingAlgorithm();
		var sortImpl=firstSortCol.getSortImplementation();
		if(sortAlg==5 && sortImpl!=null)
			sortImpl(this,sortArray,colInfo);
		else
			switch(sortAlg)
			{
				default:
				case 1:
					igtbl_quickSort1(this,sortArray,colInfo,0,this.length-1);
					break;
				case 2:
					igtbl_bubbleSort(this,sortArray,colInfo);
					break;
				case 3:
					igtbl_insertionSort(this,sortArray,colInfo);
					break;
				case 4:
					igtbl_binaryTreeSort(this,sortArray,colInfo);
					break;
			}
	}
	var cntnSort=false;
	for(var i=this.Band.Index+1;i<this.Grid.Bands.length && !cntnSort;i++)
		if(this.Grid.Bands[i].SortedColumns.length>0)
			cntnSort=true;
	
	var alternateStyle = this.Band.getRowAltClassName();
	var rowStyle = this.Band.getRowStyleClassName();
	var useAlternateRowStyle = (alternateStyle!="");
	for(var i=0;i<this.length;i++)
	{
		if(sortArray[i][0]!=i)
		{
			var san=sortArray[i][0];
			this.insert(this.remove(san),i);
			igtbl_dontHandleChkBoxChange=true;
			for(var j=0;j<chkBoxArray.length;j++)
			{
				var cell=this.getRow(i).getCell(chkBoxArray[j]);
				if(cell && cell.Element.getAttribute("chkBoxState"))
				{
					var chkBoxEl=cell.getElement().firstChild;
					if(chkBoxEl.tagName=="NOBR")
						chkBoxEl=chkBoxEl.firstChild;
					chkBoxEl.checked=(cell.Element.getAttribute("chkBoxState")=="true");
				}
			}
			igtbl_dontHandleChkBoxChange=false;
			sortArray[i][0]=i;
			for(j=i+1;j<sortArray.length;j++)
				if(sortArray[j][0]<san)
					sortArray[j][0]++;
		}
		var curRow=this.getRow(i);
		var className="";
		
		if (useAlternateRowStyle)
			className = i%2?alternateStyle:rowStyle;
		if(className && !curRow.GroupByRow)
		{		
			var e = curRow.Element;
			
			
			if(curRow.Band._optSelectRow
				)
			{
				var oldClassName=className;
				
				var colCssClass;
				if (useAlternateRowStyle)
					colCssClass=(i%2==0)?col.CssClass:col._AltCssClass;
				else
					colCssClass=col.CssClass;
				if(colCssClass && className.indexOf(colCssClass)==-1 )
					className=className+" "+colCssClass;
				var rowClass=e.getAttribute("rowClass");
				if(rowClass)
					className=className+" "+rowClass;
								
				var selectedStyle=curRow.Band.getSelClass();
				if (e.className&&selectedStyle)
				{
					if (e.className.indexOf(selectedStyle)!=-1)
					{
						className+=(" "+selectedStyle);
					}
				}
				var activationStyle=curRow.Band.Grid.Activation._cssClass;
				if (e.className&&activationStyle)
				{
					if (e.className.indexOf(activationStyle)!=-1)
					{
						className+=(" "+activationStyle);
					}
				}
				if(e.className!=className)
					e.className=className;
				className=oldClassName;
			}
			else
			{
				
				
				var j=curRow.Band.firstActiveCell;
				var colNo=0;
				var rowElem=curRow.Element;
				var nonFixed=false;
				while(j<rowElem.cells.length)
				{
					var col=curRow.Band.Columns[colNo];
					while(col && !col.hasCells())
						col=curRow.Band.Columns[++colNo];
					if(col.getFixed()===false && !nonFixed)
					{
						j=0;
						rowElem=curRow.nfElement;
						nonFixed=true;
					}
					var e = rowElem.cells[j];
					if(e)
					{
						var oldClassName=className;
						
						
						var colCssClass;
						if (useAlternateRowStyle)
							colCssClass=(i%2==0)?col.CssClass:col._AltCssClass;
						else
							colCssClass=col.CssClass;
						if(colCssClass)
							className=className+" "+colCssClass;
						var rowClass=rowElem.getAttribute("rowClass");
						if(rowClass)
							className=className+" "+rowClass;
						if(e.className!=className)
							e.className=className;
						className=oldClassName;
					}
					j++;
					colNo++;
				}
			}
		}
		if(curRow.Expandable)
		{
			var col=sortedCols.length>0?igtbl_getColumnById(sortedCols[0]):null;
			if(col && col.IsGroupBy)
			{
				if(curRow.Rows)
					curRow.Rows.sort(sortedCols.slice(1));
			}
			else if(cntnSort && curRow.Rows)
				curRow.Rows.sort(this.Grid.Bands[this.Band.Index+1].SortedColumns);
		}
	}	
	if(this.Node)
		this.reIndex(0);
	igtbl_dispose(sortArray);
	delete sortArray;
	igtbl_dispose(chkBoxArray);
	delete chkBoxArray;
}

