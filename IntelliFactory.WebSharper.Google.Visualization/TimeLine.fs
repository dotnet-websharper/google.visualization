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

namespace IntelliFactory.WebSharper.Google.Visualization

open Microsoft.FSharp.Quotations
open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Google.Visualization
open IntelliFactory.WebSharper.Google.Visualization.Base

type Timeline' [<Inline "{}">] () =
    [<DefaultValue>]
    val mutable barLabelStyle : TextStyle

    [<DefaultValue>]
    val mutable colorByRowLabel : bool

    [<DefaultValue>]
    val mutable groupByRowLabel : bool

    [<DefaultValue>]
    val mutable rowLabelTyle : TextStyle

    [<DefaultValue>]
    val mutable showRowLabels : bool

    [<DefaultValue>]
    val mutable singleColor : string

type TimelineOptions [<Inline "{}">] () =
    [<DefaultValue>]
    val mutable avoidOverlappingGridLines : bool

    [<DefaultValue>]
    val mutable backgroundColor : Color

    [<DefaultValue>]
    val mutable colors : string[]

    [<DefaultValue>]
    val mutable height : int

    [<DefaultValue>]
    val mutable timeline : Timeline'

    [<DefaultValue>]
    val mutable width : int

[<Name "google.visualization.Timeline">]
[<Require(typeof<Dependencies.JsApi>)>]
[<Require(typeof<Dependencies.Timeline>)>]
type Timeline [<Stub>] (elem: Dom.Element) =

    /// Draws the timeline.
    [<Stub>]
    member this.draw(data: DataCommon, options: TimelineOptions) : unit = X

    [<Stub>]
    member this.clearChart() = X<unit>
