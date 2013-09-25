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

/// Wrapper to set the css classes of the table.
type TableCSSClasses = {
    /// Assigns a class name to the table header row (<tr> element).
    headerRow : string

    /// Assigns a class name to the non-header rows (<tr> elements).
    tableRow : string

    /// Assigns a class name to odd table rows (<tr> elements). Note: the
    /// alternatingRowStyle option must be set to true. 
    oddTableRow : string

    /// Assigns a class name to the selected table row (<tr> element).
    selectedTableRow : string

    /// Assigns a class name to the hovered table row (<tr> element).
    hoverTableRow : string

    /// Assigns a class name to all cells in the header row (<td> element).
    headerCell : string

    /// Assigns a class name to all non-header table cells (<td> element).
    tableCell : string

    /// Assigns a class name to the cells in the row number column
    /// element). Note: the showRowNumber option must be set to true.
    rowNumberCell : string
}  with 
    [<JavaScript>] 
    static member Default: TableCSSClasses = Empty<TableCSSClasses>

// Wrapper for the different modes for sort and paging.
type EnableMode = 
    | [<Constant "enable">] Enable
    | [<Constant "event">] Event
    | [<Constant "disable">] Disable

type TableOptions = {
    /// If set to true, formatted values of cells that include HTML tags will be rendered as
    /// HTML. If set to false, most custom formatters will not work properly. Default false
    allowHtml : bool

    /// Determines if alternating color style will be assigned to odd and even rows. Default
    /// true
    alternatingRowStyle : bool

    /// The row number for the first row in the dataTable. Used only if showRowNumber is
    /// true. Default 1
    firstRowNumber : float

    /// Sets the height of the visualization's container element. You can use standard HTML
    /// units (for example, '100px', '80em', '60'). If no units are specified the number is
    /// assumed to be pixels. If not specified, the browser will set the width automatically
    /// to fit the table; if set smaller than the size required by the table, will add a
    /// vertical scroll bar. Default automatic
    height : string

    /// The number of rows in each page, when paging is enabled with the page option. Default
    /// 10
    pageSize : float

    /// Adds basic support for right-to-left languages (such as Arabic or Hebrew) by
    /// reversing the column order of the table, so that column zero is the rightmost column,
    /// and the last column is the leftmost column. This does not affect the column index in
    /// the underlying data, only the order of display. Full bi-directional (BiDi) language
    /// display is not supported by the table visualization even with this option. This
    /// option will be ignored if you enable paging (using the page option), or if the table
    /// has scroll bars because you have specified height and width options smaller than the
    /// required table size. Default false
    rtlTable : bool

    /// Sets the horizontal scrolling position, in pixels, if the table has horizontal scroll
    /// bars because you have set the width property. The table will open scrolled that many
    /// pixels past the leftmost column. T Default 0
    scrollLeftStartPosition : float

    /// If set to true, shows the row number as the first column of the table. Default false
    showRowNumber : bool

    /// The order in which the initial sort column is sorted. True for ascending, false for
    /// descending. Ignored if sortColumn is not specified. Default true
    sortAscending : bool

    /// An index of a column in the data table, by which the table is initially sorted. The
    /// column will be marked with a small arrow indicating the sort order. Default none
    sortColumn : float

    /// The first table page to display. Used only if page is in mode enable/event. Default 0
    startPage : float

    /// Sets the width of the visualization's container element. You can use standard HTML
    /// units (for example, '100px', '80em', '60'). If no units are specified the number is
    /// assumed to be pixels. If not specified, the browser will set the width automatically
    /// to fit the table; if set smaller than the size required by the table, will add a
    /// horizontal scroll bar. Default automatic
    width : string

    /// An object in which each property name describes a table element, and the property
    /// value is a string, defining a class to assign to that table element. Use this
    /// property to assign custom CSS to specific elements of your table. To use this
    /// property, assign an object, where the property name specifies the table element, and
    /// the property value is a string, specifying a class name to assign to that
    /// element. You must then define a CSS style for that class on your page. The following
    /// property names are supported:
    /// 
    ///     * headerRow - Assigns a class name to the table header row (<tr> element).
    ///     * tableRow - Assigns a class name to the non-header rows (<tr> elements).
    ///     * oddTableRow - Assigns a class name to odd table rows (<tr> elements). Note: the
    ///       alternatingRowStyle option must be set to true.
    ///     * selectedTableRow - Assigns a class name to the selected table row (<tr> element).
    ///     * hoverTableRow - Assigns a class name to the hovered table row (<tr> element).
    ///     * headerCell - Assigns a class name to all cells in the header row (<td> element).
    ///     * tableCell - Assigns a class name to all non-header table cells (<td> element).
    ///     * rowNumberCell - Assigns a class name to the cells in the row number column
    ///       (<td> element). Note: the showRowNumber option must be set to true.
    cssClassNames : TableCSSClasses

    /// If and how to enable paging through the data. Choose one of the following string
    /// values:
    ///     * 'enable' - The table will include page-forward and page-back buttons. Clicking
    ///       on these buttons will perform the paging operation and change the displayed
    ///       page. You might want to also set the pageSize option.
    ///     * 'event' - The table will include page-forward and page-back buttons, but
    ///       clicking them will trigger a 'page' event and will not change the displayed
    ///       page. This option should be used when the code implements its own page turning
    ///       logic. See the TableQueryWrapper example for an example of how to handle paging
    ///       events manually.
    ///     * 'disable' - [Default] Paging is not supported.
    page : EnableMode

    /// If and how to sort columns when the user clicks a column heading. If sorting is
    /// enabled, consider setting the sortAscending and sortColumn properties as well. Choose
    /// one of the following string values:
    /// 
    ///     * 'enable' - [Default] Users can click on column headers to sort by the clicked
    ///       column. When users click on the column header, the rows will be automatically
    ///       sorted, and a 'sort' event will be triggered.
    ///     * 'event' - When users click on the column header, a 'sort' event will be
    ///       triggered, but the rows will not be automatically sorted. This option should be
    ///       used when the page implements its own sort. See the TableQueryWrapper example
    ///       for an example of how to handle sorting events manually.
    ///     * 'disable' - Clicking a column header has no effect.
    sort : EnableMode
} with 
    [<JavaScript>] 
    static member Default: TableOptions = Empty<TableOptions>

type SortOrder = {
    column: float
    ascending: bool
    sortedIndexes: float []
}

[<Name "google.visualization.Table">]
[<Require(typeof<Dependencies.Table>)>]
type Table =
    [<Stub>]
    new (elem: Dom.Element) = {}

    /// Draws the table.
    [<Stub>]
    member this.draw(data: DataCommon, options: TableOptions) : unit = X

    /// Standard getSelection implementation. Selection elements are
    /// all row elements. Can return more than one selected row. The row
    /// indexes in the selection object refer to the original data table
    /// regardless of any user interaction (sort, paging, etc.).
    [<Stub>]
    member this.getSelection() : obj = X

    /// Call this method to retrieve information about the current
    /// sort state of a table that has been sorted (typically by the
    /// user, who has clicked on a column heading to sort the rows by a
    /// specific column).
    [<Stub>]
    member this.getSortOrder() : SortOrder = X

    /// Standard setSelection() implementation, but can only select
    /// entire rows, or multiple rows. The row indexes in the selection
    /// object refer to the original data table regardless of any user
    /// interaction (sort, paging, etc.).
    [<Stub>]
    member this.setSelection(selection: obj) : unit = X
