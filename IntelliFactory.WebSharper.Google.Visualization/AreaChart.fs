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

type Color [<Inline "{}">] private () =

    [<DefaultValue>]
    val mutable stroke : string
    
    [<DefaultValue>]        
    val mutable fill : string
    
    [<DefaultValue>]
    val mutable strokeSize : int
    
    [<Inline "$s">]
    static member HtmlColor(s: string) : Color = X

    [<Inline>]
    [<JavaScript>]
    static member FromProperties (stroke: string) 
                                 (fill: string) 
                                 (strokeSize: int) =
        new Color(stroke = stroke, fill = fill, strokeSize = strokeSize)


type LegendPosition = 
    | [<Constant "right" >] Right
    // | [<Constant "left" >]  Left // Disabled with CoreCharts
    | [<Constant "top" >]   Top
    | [<Constant "bottom" >] Bottom
    | [<Constant "none" >] None

type AreaChartOptions = {

    /// The background color for the main area of the chart.
    /// May be one of the following options:
    /// <ul>
    /// <li>A string with color supported by HTML, for example 'red' or '#00cc00'</li>
    /// <li>An object with properties <code>stroke</code> <code>fill</code> and <code>strokeSize</code>.
    /// <code>stroke</code> and <code>fill</code> should be a string with a color. strokeSize is a number.
    /// For example: <code>{backgroundColor: {stroke:'black', fill:'#eee', strokeSize: 1}</code>.
    /// To use just fill, without a stroke, use <code>stroke:null, strokeSize: 0</code>.</li>
    /// </ul>
    /// Default Value: default color
    backgroundColor : Color

    // The default font size, in pixels, of all text in the chart. You can override this using properties for specific chart elements.
    fontSize : float
    
    // The default font face for all text in the chart. You can override this using properties for specific chart elements.
    fontName : string

    /// The colors to use for the chart elements.
    /// An array of strings. Each element is a string that is a color supported by HTML,
    /// for example 'red' or '#00cc00'.
    /// Default Value: Default colors
    colors : string []

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

    /// Line width in pixels. Use zero to hide all lines and show only the points.
    /// Default Value: 2
    lineWidth : float
    
    /// Size of displayed points in pixels. Use zero to hide all points.
    /// Default Value: 3
    pointSize : float

    /// If set to true, will draw categories from right to left. The default is to draw left-to-right.
    /// Default Value: false
    reverseCategories : bool
    
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
    static member Default : AreaChartOptions = Empty<AreaChartOptions>

/// An area chart that is rendered within the browser using SVG or VML. 
/// Displays tips when clicking on points. Animates lines when clicking 
/// on legend entries. 
[<Name "google.visualization.AreaChart">]
[<Require(typeof<Dependencies.AreaChart>)>]
type AreaChart =
    [<Stub>]
    new (elem: Dom.Element) = {}

    /// Draws the chart. You can speed up response time for the second and later calls to
    /// draw() by using the allowRedraw property.
    [<Stub>]
    member this.draw(data: DataCommon, options: AreaChartOptions) : unit = X

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
