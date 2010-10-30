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
type OrgChartOptions = {
    /// Determines if double click will collapse a node.
    /// Default Value: false
    allowCollapse : bool
     
    /// If set to true, names that includes HTML tags will be rendered as HTML.
    /// Default Value: false
    allowHtml : bool
     
    /// A class name to assign to node elements. Apply CSS to this class name
    /// to specify colors or styles for the chart elements.
    /// Default Value: default class name
    nodeClass : string
     
    /// A class name to assign to selected node elements. Apply CSS to this class
    /// name to specify colors or styles for selected chart elements.
    /// Default Value: default class name
    selectedNodeClass : string
     
    /// 'small', 'medium' or 'large'
    /// Default Value: 'medium'
    size : string
} with
    [<JavaScript>]
    static member Default : OrgChartOptions = Empty<OrgChartOptions>

/// A line chart that is rendered within the browser using SVG or VML. Displays 
/// tips when clicking on points. Animates lines when clicking on legend entries. 
[<Stub>]
[<Name "google.visualization.OrgChart">]
[<Require(typeof<Dependencies.OrgChart>)>]
type OrgChart =
    new (elem: Dom.Element) = {}

    /// Draws the chart. You can speed up response time for the second and later calls to
    /// draw() by using the allowRedraw property.
    member this.draw(data: DataCommon, options: OrgChartOptions) : unit = X

    /// Standard getSelection implementation. Selection elements are
    /// all row elements. Can return more than one selected row. The row
    /// indexes in the selection object refer to the original data table
    /// regardless of any user interaction (sort, paging, etc.).
    member this.getSelection() : obj = X

    /// Collapses or expands the node.
    /// * row - Index of the row to expand or collapse.
    /// * collapsed Whether to collapse or expand the row, where true means collapse.
    member this.collapse(row: float, collapsed: bool) : unit = X

    /// Standard setSelection() implementation, but can only select
    /// entire rows, or multiple rows. The row indexes in the selection
    /// object refer to the original data table regardless of any user
    /// interaction (sort, paging, etc.).
    member this.setSelection(selection: obj) : unit = X

    /// Returns an array with the indexes of the children of the given node.
    member this.getChildrenIndexes(row: float) : float [] = X

    /// Returns an array with the list of the collapsed node's indexes.
    member this.getCollapsedNodes : float [] = X

