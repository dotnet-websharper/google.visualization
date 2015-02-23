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

type AreaChartOptions [<Inline "{}">] () =
    inherit ChartOptionsCommon()

    /// The default opacity of the colored area under an area chart
    /// series, where 0.0 is fully transparent and 1.0 is fully
    /// opaque. To specify opacity for an individual series, set the
    /// areaOpacity value in the series property.
    [<DefaultValue>]
    val mutable areaOpacity : float

    /// If set to true, line values are stacked (accumulated).
    /// Default Value: false
    [<DefaultValue>]
    val mutable isStacked : bool

    /// Line width in pixels. Use zero to hide all lines and show only the points.
    /// Default Value: 2
    [<DefaultValue>]
    val mutable lineWidth : float
    
    /// Size of displayed points in pixels. Use zero to hide all points.
    /// Default Value: 3
    [<DefaultValue>]
    val mutable pointSize : float

    /// Specifies properties for individual vertical axes, if the
    /// chart has multiple vertical axes. Each child object is a vAxis
    /// object, and can contain all the properties supported by vAxis.
    [<DefaultValue>]
    val mutable vAxes : Axis[]

/// An area chart that is rendered within the browser using SVG or VML. 
/// Displays tips when clicking on points. Animates lines when clicking 
/// on legend entries. 
[<Name "google.visualization.AreaChart">]
[<Require(typeof<Dependencies.AreaChart>)>]
type AreaChart [<Stub>] (elem: Dom.Element) =
    inherit ChartCommon<AreaChartOptions>()
