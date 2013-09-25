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

type DataMode =
    | [<Constant "regions">] Regions
    | [<Constant "markers">] Markers

type GeoMapOptions = {
    /// <p>The area to display on the map. (Surrounding areas will be displayed
    /// as well.) Can be either a country code (in uppercase <a href="http://en.wikipedia.org/wiki/ISO_3166-1">ISO-3166</a> format),
    /// or a one of the following strings:</p>
    /// <ul>
    /// <li><code>world</code> - (Whole world)</li>
    /// <li><code>005</code> - (South America)</li>
    /// <li><code>013</code> - (Central America)</li>
    /// <li><code>021</code> - (North America)</li>
    /// <li><code>002</code> - (All of Africa)</li>
    /// <li><code>017</code> - (Central Africa)</li>
    /// <li><code>015</code> - (Northern Africa)</li>
    /// <li><code>018</code> - (Southern Africa)</li>
    /// <li><code>030</code> - (Eastern Asia)</li>
    /// <li><code>034</code> - (Southern Asia)</li>
    /// <li><code>035</code> - (Asia/Pacific region)</li>
    /// <li><code>143</code> - (Central Asia)</li>
    /// <li><code>145</code> - (Middle East)</li>
    /// <li><code>151</code> - (Northern Asia)</li>
    /// <li><code>154</code> - (Northern Europe)</li>
    /// <li><code>155</code> - (Western Europe)</li>
    /// <li><code>039</code> - (Southern Europe)</li>
    /// </ul>
    /// <p>Geomap does not enable scrolling
    /// or dragging behavior, and only limited zooming behavior. A basic zoom
    /// out can be enabled by setting the <code><a href="#showzoomout">showZoomOut</a></code> property.</p>
    /// Default Value: 'world'
    region : Region
     
    /// <p>How to display values on the map. Two
    /// values are supported:</p>
    /// <ul>
    /// <li><code>regions</code> - Colors a whole region with the appropriate
    /// color. This option cannot be used with latitude/longitude addresses.
    /// See <a href="#regionsexample">Regions Example</a>.</li>
    /// <li><code>markers</code> - Displays a dot over a region, with the color
    /// and size indicating the value. See <a href="#markersexample">Markers
    /// Example</a>.</li>
    /// </ul>
    /// Default Value: 'regions'
    dataMode : DataMode
     
    /// Width of the visualization. If no units
    /// are given, the default unit is pixels.
    /// Default Value: '556px'
    width : string
     
    /// Height of the visualization. If no units
    /// are given, the default unit is pixels.
    /// Default Value: '347px'
    height : string
     
    /// Color gradient to assign to values in the
    /// visualization. You must have at least two values; the gradient will include
    /// all your values, plus calculated intermediary values, with the lightest
    /// color as the smallest value, and the darkest color as the highest.
    /// Default Value: [0xE0FFD4, 0xA5EF63, 0x50AA00, 0x267114]
    colors : int []
     
    /// If true, display a legend for the map.
    /// Default Value: true
    showLegend : bool
     
    /// If true, display a button with the label
    /// specified by the <code>zoomOutLabel</code> property. <em><strong>Note that
    /// this button does nothing when clicked</strong></em>, except throw the <code><a href="#zoomoutevent">zoomOut</a></code> event.
    /// To handle zooming, catch this event and change the <code>region</code> option.
    /// You can only specify <code>showZoomOut</code> if
    /// the <code>region</code> option
    /// is smaller than the world view. One way of enabling zoom in behavior would
    /// be to listen for the <code>regionClick</code> event, change
    /// the <code>region</code> property to the appropriate region, and reload the map.
    /// Default Value: false
    showZoomOut : bool
     
    /// Label for the zoom button.
    /// Default Value: 'Zoom Out'
    zoomOutLabel : string
} with
    [<JavaScript>]
    static member Default : GeoMapOptions = Empty<GeoMapOptions>

/// A geomap is a map of a country, continent, or region map, with colors and values 
/// assigned to specific regions. Values are displayed as a color scale, and you can
/// specify optional hovertext for regions. The map is rendered in the browser using
/// an embedded Flash player. Note that the map is not scrollable or draggable, but 
/// can be configured to allow zooming.
[<Name "google.visualization.GeoMap">]
[<Require(typeof<Dependencies.GeoMap>)>]
type GeoMap =
    [<Stub>]
    new (elem: Dom.Element) = {}

    /// Draws the chart. You can speed up response time for the second and later calls to
    /// draw() by using the allowRedraw property.
    [<Stub>]
    member this.draw(data: DataCommon, options: GeoMapOptions) : unit = X

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
