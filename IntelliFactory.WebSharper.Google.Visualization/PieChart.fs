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

[<JavaScriptType>]
module Enumerations =
    [<JavaScriptType>]
    type PieChartLegendPosition = 
        | [<Constant "right" >] Right
        | [<Constant "left" >]  Left
        | [<Constant "top" >]   Top
        | [<Constant "bottom" >] Bottom
        | [<Constant "none" >] None
        | [<Constant "label" >] Label

[<JavaScriptType>]
type PieChartOptions = {

    /// The background color for the main area of the chart.
    /// One of the following options:
    /// <ul>
    /// <li>A string with color supported by HTML, for example 'red' or '#00cc00',
    /// <em><strong>or</strong></em></li>
    /// <li>A description of a n object with the following properties:
    /// <ul>
    /// <li><code>stroke</code> - An HTML color string describing the chart
    /// border color.</li>
    /// <li><code>fill</code> - An HTML color string describing the chart background
    /// color.</li>
    /// <li><code>strokeSize</code> - A number describing the thickness, in
    /// pixels, of the chart border. For no border, this can be set to 0.<br/>
    /// <strong>Example</strong>: <code>{backgroundColor:
    /// {stroke:'black', fill:'#eee', strokeSize: 1}</code>.</li>
    /// </ul>
    /// </li>
    /// </ul>
    /// Default Value: default color
    backgroundColor : Color
    
    color : string
          
    colors : string []
     
    enableEvents : bool
     
    /// Height of the chart in pixels.
    /// Default Value: Container's height
    height : float
     
    /// If set to true, displays a three-dimensional chart.
    /// Default Value: false
    is3D : bool
    
    labels : string
     
    /// Position and type of legend. Can be one of the following:
    /// <ul>
    /// <li>'right' - To the right of the chart.</li>
    /// <li>'left' - To the left of the chart.</li>
    /// <li>'top' - Above the chart.</li>
    /// <li>'bottom' - Below the chart.</li>
    /// <li>'label' - Labels near slices.</li>
    /// <li>'none' - No legend is displayed.</li>
    /// </ul>
    /// Default Value: 'right'
    legend : Enumerations.PieChartLegendPosition 
     
    /// Text to display above the chart.
    /// Default Value: no title
    title : string
 
    /// Width of the chart in pixels.
    /// Default Value: Container's width
    width : float
} with  
    [<JavaScript>]
    static member Default : PieChartOptions = Empty<PieChartOptions>

/// A line chart that is rendered within the browser using SVG or VML. Displays 
/// tips when clicking on points. Animates lines when clicking on legend entries. 
[<Stub>]
[<Name "google.visualization.PieChart">]
[<Require(typeof<Dependencies.CoreChart>)>]
type PieChart =
    new (elem: Dom.Element) = {}

    /// Draws the chart. You can speed up response time for the second and later calls to
    /// draw() by using the allowRedraw property.
    member this.draw(data: DataCommon, options: PieChartOptions) : unit = X

    /// Standard getSelection implementation. Selection elements are
    /// all row elements. Can return more than one selected row. The row
    /// indexes in the selection object refer to the original data table
    /// regardless of any user interaction (sort, paging, etc.).
    member this.getSelection() : obj = X

    /// Standard setSelection() implementation, but can only select
    /// entire rows, or multiple rows. The row indexes in the selection
    /// object refer to the original data table regardless of any user
    /// interaction (sort, paging, etc.).
    member this.setSelection(selection: obj) : unit = X
