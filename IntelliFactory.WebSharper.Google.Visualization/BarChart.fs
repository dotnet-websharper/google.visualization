// $begin{copyright}
//
// This file is confidential and proprietary.
//
// Copyright (c) IntelliFactory, 2004-2010.
//
// All rights reserved.  Reproduction or use in whole or in part is
// prohibited without the written consent of the copyright holder.
//-----------------------------------------------------------------
// $end{copyright}

namespace IntelliFactory.WebSharper.Google.Visualization.Visualizations

open Microsoft.FSharp.Quotations
open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Google.Visualization
open IntelliFactory.WebSharper.Google.Visualization.Base
open IntelliFactory.WebSharper.Google.Visualization.Base.Helpers


// Dummy type for colors used that posess the is3D property.
type Color3D [<Inline "({})">] private () =

    [<DefaultValue>]
    val mutable private color : string
    
    [<DefaultValue>]
    val mutable private darker : string

    [<Inline "$s">]
    static member HtmlColor (s: string) : Color3D = X

    [<Inline>]
    [<JavaScript>]
    static member FromProperties (color: string) (darker: string) =
        new Color3D(color = color, darker = darker)
    

type BarChartOptions = {

    /// The background color for the main area of the chart.
    /// May be one of the following options:
    /// <ul> 
    /// <li>A string with color supported by HTML, for example 'red' or '#00cc00'</li> 
    /// <li>An object with properties <code>stroke</code> <code>fill</code> and <code>strokeSize</code>.
    /// <code>stroke</code> and <code>fill</code> should be a string with a color. strokeSize is a number.
    /// For example: <code>{backgroundColor: {stroke:'black', fill:'#eee', strokeSize: 1}</code>.
    /// To use just fill, without a stroke, use <code>stroke:null, strokeSize: 0</code>.         </li> 
    /// </ul>    
    /// Default Value: default color
    backgroundColor : Color

    /// <p>An array of colors, where each element specifies the color of
    /// one series. You should specify one array element for each series.</p> 
    /// <ul> 
    /// <li>If <code>is3D=false</code>, this is an array of HTML colors. Example:
    /// colors:['00FF00','orange']</li> 
    /// <li>If <code>is3D=true</code>, this is an array of either HTML colors, or
    /// objects of this type: <code>{color:<em>face_color</em>,
    /// darker:<em>shade_color</em>}</code> where <code>color</code> is the
    /// element's face color, and <code>darker</code> is
    /// the shade color. However, if you specify an HTML color for a 3D object,
    /// face and shade will be the same color, and the 3D effect will be reduced.
    /// Example: <code>{is3D:true,
    /// colors:[{color:'FF0000', darker:'680000'}, {color:'cyan', darker:'deepskyblue'}]}</code></li> 
    /// </ul>
    /// Default Value: Default colors
    colors : Color3D []

    hAxis : Axis

    /// Height of the chart in pixels.
    /// Default Value: Container's height
    height : float

    /// If set to true, line values are stacked (accumulated).
    /// Default Value: false
    isStacked : bool

    /// Position and type of legend. Can be one of the following:
    /// <ul> 
    /// <li>'right' - To the right of the chart.</li> 
    /// <li>'left' - To the left of the chart.</li> 
    /// <li>'top' - Above the chart.</li> 
    /// <li>'bottom' - Below the chart.</li> 
    /// <li>'none' - No legend is displayed.</li> 
    /// </ul>    
    /// Default Value: 'right'
    legend : LegendPosition

    legendTextStyle : TextStyle

    reverseCategories : int
    
    /// If true, will show category labels. If false, will not.
    /// Default Value: true
    showCategories : bool

    /// Text to display above the chart.
    /// Default Value: no title
    title : string

    titleTextStyle : TextStyle

    tooltipTextStyle : TextStyle

    vAxis : Axis

    /// Width of the chart in pixels.
    /// Default Value: Container's width
    width : float
} with
    [<JavaScript>]
    static member Default : BarChartOptions = Empty<BarChartOptions>


/// A horizontal bar chart that is rendered within the browser using 
/// SVG or VML. Displays tips when clicking on points. Animates lines
/// when clicking on legend entries. For a vertical version of this 
/// chart, see the Column Chart.
[<Name "google.visualization.BarChart">]
[<Require(typeof<Dependencies.CoreChart>)>]
type BarChart =
    [<Stub>]
    new (elem: Dom.Element) = {}

    /// Draws the chart. You can speed up response time for the second and later calls to
    /// draw() by using the allowRedraw property.
    [<Stub>]
    member this.draw(data: DataCommon, options: BarChartOptions) : unit = X

    /// Standard getSelection implementation. Selection elements are
    /// all row elements. Can return more than one selected row. The row
    /// indexes in the selection object refer to the original data table
    /// regardless of any user interaction (sort, paging, etc.).
    [<Stub>]
    member this.getSelection() : obj = X

    /// Standard setSelection() implementation, but can only select
    /// entire rows, or multiple rows. The row indexes in the selection
    /// object refer to the original data table regardless of any user
    /// interaction (sort, paging, etc.).
    [<Stub>]
    member this.setSelection(selection: obj) : unit = X
