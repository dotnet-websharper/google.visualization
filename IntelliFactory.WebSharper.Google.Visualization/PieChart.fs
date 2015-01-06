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
open IntelliFactory.WebSharper.JavaScript
open IntelliFactory.WebSharper.Google.Visualization
open IntelliFactory.WebSharper.Google.Visualization.Base

module Enumerations =
    [<RequireQualifiedAccess>]
    type PieChartLegendPosition = 
        | [<Constant "right" >] Right
        | [<Constant "left" >]  Left
        | [<Constant "top" >]   Top
        | [<Constant "bottom" >] Bottom
        | [<Constant "none" >] None
        | [<Constant "label" >] Label

[<RequireQualifiedAccess>]
type PieSliceText =
    | [<Constant "percentage">] Percentage
    | [<Constant "value">] Value
    | [<Constant "label">] Label
    | [<Constant "none">] None

type PieSlice [<Inline "{}">] () =
    [<DefaultValue>]
    val mutable color : string

    [<DefaultValue>]
    val mutable offset : float

    [<DefaultValue>]
    val mutable textStyle : TextStyle

type PieChartOptions [<Inline "{}">] () =
    inherit ChartOptionsCommon()

    [<DefaultValue>]
    val mutable is3D : bool

    [<DefaultValue>]
    val mutable pieHole : float

    [<DefaultValue>]
    val mutable pieSliceBorderColor : string

    [<DefaultValue>]
    val mutable pieSliceText : PieSliceText

    [<DefaultValue>]
    val mutable pieSliceTextStyle : TextStyle

    [<DefaultValue>]
    val mutable pieStartAngle : float

    [<DefaultValue>]
    val mutable pieResidueSliceColor : string

    [<DefaultValue>]
    val mutable pieResidueSliceLabel : string

    [<DefaultValue>]
    val mutable slices : PieSlice[]

    [<DefaultValue>]
    val mutable sliceVisibilityThreshold : float

/// A line chart that is rendered within the browser using SVG or VML. Displays 
/// tips when clicking on points. Animates lines when clicking on legend entries. 
[<Name "google.visualization.PieChart">]
[<Require(typeof<Dependencies.CoreChart>)>]
type PieChart [<Stub>] (elem: Dom.Element) =
    inherit ChartCommon<PieChartOptions> ()
