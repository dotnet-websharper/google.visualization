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

namespace WebSharper.Google.Visualization

open Microsoft.FSharp.Quotations
open WebSharper
open WebSharper.JavaScript
open WebSharper.Google.Visualization
open WebSharper.Google.Visualization.Base

/// Dummy type for the possible regions. 
/// the IM prefix stands for Intensity map because the geomap already
/// uses the "Region" name.
type IMRegion =
    | [< Constant "world">]  World
    | [< Constant "africa">]  Africa
    | [< Constant "asia">]  Asia
    | [< Constant "europe">]  Europe
    | [< Constant "middle_east">]  MiddleEast
    | [< Constant "south_america">]  SouthAmerica
    | [< Constant "usa">]  USA

type IntensityMapOptions [<Inline "{}">] () =

    /// The colors to use for each tab.
    /// An array of strings. Each element is a string in the format #rrggbb.
    /// For example '#00cc00'.
    ///
    /// Default Value: Default colors
    [<DefaultValue>]
    val mutable colors : string []
     
    ///
    /// <p>Height of the map in pixels.
    /// The maximum height of the visualization is 220.</p>
    /// <p>Note that this height assumes a one-row tab. If your tab text is long, it
    /// will wrap the tab to multiple lines, and the extra lines will exceed the
    /// specified height.</p>
    /// Default Value: 220
    [<DefaultValue>]
    val mutable height : float
     
    /// The required region. Possible values are:
    /// 'world', 'africa', 'asia', 'europe', 'middle_east', 'south_america', and
    /// 'usa'.
    ///
    /// Default Value: 'world'
    [<DefaultValue>]
    val mutable region : IMRegion
     
    /// The intensity map can display one or more numeric columns.
    /// Each column is displayed as a separate map, and tabs on top enable selection
    /// of which map to show.
    /// When the data table contains only one numeric column,
    /// the tabs are not displayed.
    /// To display tabs even for a single numeric column, set this option to true.
    ///
    /// Default Value: false
    [<DefaultValue>]
    val mutable showOneTab : bool
     
    /// Width of the map in pixels.<br/>
    /// Note: The maximum width of the visualization is 440.
    ///
    /// Default Value: 440
    [<DefaultValue>]
    val mutable width : float

/// An intensity map that highlights regions or countries based on relative values 
[<Name "google.visualization.IntensityMap">]
[<Require(typeof<Dependencies.JsApi>)>]
[<Require(typeof<Dependencies.IntensityMap>)>]
type IntensityMap =
    [<Stub>]
    new (elem: Dom.Element) = {}

    /// Draws the chart. You can speed up response time for the second and later calls to
    /// draw() by using the allowRedraw property.
    [<Stub>]
    member this.draw(data: DataCommon, options: IntensityMapOptions) : unit = X

    /// Standard getSelection() implementation. Supports only selection of a single column.
    [<Stub>]
    member this.getSelection() : obj = X

    /// Standard setSelection() implementation. Supports only selection of a single column. 
    [<Stub>]
    member this.setSelection(selection: obj) : unit = X
