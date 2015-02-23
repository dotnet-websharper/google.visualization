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

type GaugeOptions [<Inline "{}">] () =

    /// The lowest value for a range marked by a green color.
    ///
    /// Default Value: none
    [<DefaultValue>]
    val mutable greenFrom : float
     
    /// The highest value for a range marked by a green color.
    ///
    /// Default Value: none
    [<DefaultValue>]
    val mutable greenTo : float
     
    /// Height of the chart in pixels.
    /// Default Value: Container's width
    [<DefaultValue>]
    val mutable height : float
     
    /// Labels for major tick marks. The number of labels define the number of
    /// major ticks in all gauges. The default is five major ticks, with the
    /// labels of the minimal and maximal gauge value.
    ///
    /// Default Value: none
    [<DefaultValue>]
    val mutable majorTicks : string []
     
    /// The maximal value of a gauge.
    ///
    /// Default Value: 100
    [<DefaultValue>]
    val mutable max : float
     
    /// The minimal value of a gauge.
    ///
    /// Default Value: 0
    [<DefaultValue>]
    val mutable min : float
     
    /// The number of minor tick section in each major tick section.
    ///
    /// Default Value: 2
    [<DefaultValue>]
    val mutable minorTicks : float
     
    /// The lowest value for a range marked by a red color.
    ///
    /// Default Value: none
    [<DefaultValue>]
    val mutable redFrom : float
     
    /// The highest value for a range marked by a red color.
    ///
    /// Default Value: none
    [<DefaultValue>]
    val mutable redTo : float
     
    /// Width of the chart in pixels.
    /// Default Value: Container's width
    [<DefaultValue>]
    val mutable width : float
     
    /// The lowest value for a range marked by a yellow color.
    ///
    /// Default Value: none
    [<DefaultValue>]
    val mutable yellowFrom : float
     
    /// The highest value for a range marked by a yellow color.
    ///
    /// Default Value: none
    [<DefaultValue>]
    val mutable yellowTo : float


/// One or more gauges are rendered within the browser using SVG or VML. 
[<Name "google.visualization.Gauge">]
[<Require(typeof<Dependencies.Gauge>)>]
type Gauge [<Stub>] (elem: Dom.Element) =
    inherit ChartCommon<GaugeOptions> ()
