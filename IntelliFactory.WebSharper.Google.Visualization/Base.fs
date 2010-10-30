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

namespace IntelliFactory.WebSharper.Google.Visualization.Base

open Microsoft.FSharp.Quotations
open IntelliFactory.WebSharper

[<AutoOpen>]
module internal Helpers =
    [<JavaScript>]
    let X<'T> = Unchecked.defaultof<'T>
    
    [<Inline "{}">]
    let Empty<'T> : 'T = X

// Simple wrap to improve IntelliSense
type ColumnType = 
    | [<Constant "string">]    StringType
    | [<Constant "number">]    NumberType
    | [<Constant "boolean">]   BooleanType
    | [<Constant "date">]      DateType
    | [<Constant "datetime">]  DateTimeType
    | [<Constant "timeofday">] TimeOfDayType

/// Cell wrap        
type Cell = {
    /// The cell value. The data type should match the column data type. 
    /// If null, the whole object should be empty and have neither v nor f properties.
    v : obj
    /// A string version of the v value, formatted for display. The values should match,
    /// so if you specify Date(2008, 0, 1) for v, you should specify "January 1, 2008" 
    /// or some such string for this property. This value is not checked against the v 
    /// value. The visualization will not use this value for calculation, only as a label
    /// for display. If omitted, a string version of v will be used.
    f : string
    /// An object that is a map of custom values applied to the cell. These values can be
    /// of any JavaScript type. If your visualization supports any cell-level properties, 
    /// it will describe them; otherwise, this property will be ignored. 
    /// Example: p:{style: 'border: 1px solid green;'}.
    p : obj
} with
    [<JavaScript>]
    /// Builds an empty cell.
    static member Empty = Empty<Cell>
    [<JavaScript>]
    /// Builds a cell consisting of only a value.
    static member Value(value: obj) = { Cell.Empty with v = value }

/// Wrap for sorting the views.
type SortType [<Inline "{}">] private () =

    [<DefaultValue>]
    val mutable private column : int
    
    [<DefaultValue>]
    val mutable private desc : bool
    
    // Sorts by the given column ascendent
    [<Inline>]
    [<JavaScript>]
    static member By(column: int) : SortType =
        new SortType(column = column)

    [<Inline>]
    [<JavaScript>]
    // Sorts by the given column according to the given flag
    static member By(column: int, desc: bool) =
        new SortType(column = column, desc = desc)

/// Dummy type that contains common functions of DataTable and DataView
[<Stub>]
type DataCommon() =

    /// Returns the identifier of a given column specified by the column index in the
    /// underlying table For data tables that are retrieved by queries, the column identifier
    /// is set by the data source, and can be used to refer to columns when using the query
    /// language.
    member this.getColumnId(columnIndex: int) : string = X

    /// Returns the label of a given column specified by the column index in the underlying
    /// table.  The column label is typically displayed as part of the visualization. For
    /// example the column label can be displayed as a column header in a table, or as the
    /// legend label in a pie chart.  For data tables that are retrieved by queries, the
    /// column label is set by the data source, or by the label clause of the query language.
    member this.getColumnLabel(columnIndex) : string = X

    /// Returns the formatting pattern used to format the values of the specified column.
    /// 
    ///     * columnIndex should be a number greater than or equal to zero, and less than the
    ///       number of columns as returned by the getNumberOfColumns() method.
    /// 
    /// For data tables that are retrieved by queries, The column pattern is set by the data
    /// source, or by the format clause of the query language. An example of a pattern is
    /// '#,##0.00'. For more on patterns see the query language reference.
    member this.getColumnPattern(columnIndex) : string = X

    /// Returns the value of a named property, or null if no such property is set for the
    /// specified column. The return type varies, depending on the property.
    /// 
    ///     * columnIndex should be a number greater than or equal to zero, and less than the
    ///       number of columns as returned by the getNumberOfColumns() method.  
    ///     * name is the property name, as a string.
    member this.getColumnProperty(columnIndex: int, name: string) : obj = X

    /// Returns the minimal and maximal values of values in a specified column. The returned
    /// object has properties min and max. If the range has no values, min and max will
    /// contain null.
    /// 
    /// columnIndex should be a number greater than or equal to zero, and less than the
    /// number of columns as returned by the getNumberOfColumns() method.
    member this.getColumnRange(columnIndex: int) : obj = X

    /// Returns the type of a given column specified by the column index.
    /// 
    ///     * columnIndex should be a number greater than or equal to zero, and less than the
    ///       number of columns as returned by the getNumberOfColumns() method.
    /// 
    /// The returned column type can be one of the following: 'string' 'number' 'boolean'
    /// 'date' 'datetime' 'timeofday'
    member this.getColumnType(columnIndex: int) : ColumnType = X


    /// Returns the unique values in a certain column, in ascending order.
    /// 
    ///     * columnIndex should be a number greater than or equal to zero, and less than the
    ///       number of columns as returned by the getNumberOfColumns() method.
    /// 
    /// The type of the returned objects is the same as that returned by the getValue method.
    member this.getDistinctValues(index: int) : obj [] = X

    /// Returns the row indexes for rows that match all of the given filters. The indexes
    /// are returned in ascending order. The output of this method can be used as input to
    /// DataView.setRows() to change the displayed set of rows in a visualization.
    /// 
    /// filters - An array of objects that describe an acceptable cell value. A row index is
    /// returned by this method if it matches all of the given filters. Each filter is an
    /// object with a numeric column property that specifies the index of the column in the
    /// row to assess, plus one of the following:
    /// 
    ///     * A value property with a value that must be matched exactly by the cell in the
    ///       specified column. The value must be the same type as the column; or
    /// 
    ///     * One or both of the following properties, the same type as the column being
    ///       filtered:
    /// 
    ///           o minValue - A minimum value for the cell. The cell value in the specified
    ///           column must be greater than or equal to this value.
    ///           o maxValue - A maximum value for the cell. The cell value in the specified
    ///           column must be less than or equal to this value.
    /// 
    member this.getFilteredRows(filters: obj []) : int [] = X

    /// Returns the formatted value of the cell at the given row and column indexes.
    /// 
    ///     * rowIndex should be a number greater than or equal to zero, and less than the
    ///       number of rows as returned by the getNumberOfRows() method.
    /// 
    ///     * ColumnIndex should be a number greater than or equal to zero, and less than the
    ///       number of columns as returned by the getNumberOfColumns() method.
    /// 
    member this.getFormattedValue(rowIndex: int, columnIndex: int) : string = X

    /// Returns the number of columns in the table
    member this.getNumberOfColumns() : int = X

    /// Returns the number of rows in the table.
    member this.getNumberOfRows() : int = X

    /// Returns a map of all the properties for the specified cell. Note that the properties
    /// object is returned by reference, so changing values in the retrieved object changes
    /// them in the DataTable.
    /// 
    ///     * rowIndex is the cell's row index.
    ///     * columnIndex is the cell's column index.
    member this.getProperties(rowIndex: int, columnIndex: int) : int = X

    /// Returns the value of a named property, or null if no such property is set for the
    /// specified cell. The return type varies, depending on the property.
    /// 
    ///     * rowIndex should be a number greater than or equal to zero, and less than the
    ///       number of rows as returned by the getNumberOfRows() method.
    /// 
    ///     * columnIndex should be a number greater than or equal to zero, and less than the
    ///       number of columns as returned by the getNumberOfColumns() method.
    /// 
    ///     * name is a string with the property name.
    member this.getProperty(rowIndex: int, columnIndex: int, name: string) : obj = X

    /// Returns the value of a named property, or null if no such property is set for the
    /// specified row. The return type varies, depending on the property.
    /// 
    ///     * rowIndex should be a number greater than or equal to zero, and less than the
    ///       number of rows as returned by the getNumberOfRows() method.
    /// 
    ///     * name is a string with the property name.
    member this.getRowProperty(rowIndex: int, name: string) : obj = X

    /// Returns a sorted version of the table without modifying the order of the underlying
    /// data. To permanently sort the underlying data, call sort(). You can specify sorting
    /// in a number of ways, depending on the type you pass in to the sortColumns parameter:
    /// 
    ///     * A single number specifies the index of the column to sort by. Sorting will be
    ///       in ascending order.
    /// 
    ///     * A single object that contains the number of the column index to sort by, and an
    ///       optional boolean property desc. If desc is set to true, the specific column
    ///       will be sorted in descending order; otherwise, sorting is in ascending order.
    /// 
    ///     * An array of numbers of the column indexes by which to sort. The first number is
    ///       the primary column by which to sort, the second one is the secondary, and so
    ///       on. This means that when two values in the first column are equal, the values
    ///       in the next column are compared, and so on.
    /// 
    ///     * An array of objects, each one with the number of the column index to sort by,
    ///       and an optional boolean property desc. If desc is set to true, the specific
    ///       column will be sorted in descending order (the default is ascending order). The
    ///       first object is the primary column by which to sort, the second one is the
    ///       secondary, and so on. This means that when two values in the first column are
    ///       equal, the values in the next column are compared, and so on.
    /// 
    /// The returned value is an array of numbers, each number is an index of a DataTable
    /// row. Iterating on the DataTable rows by the order of the returned array will result
    /// in rows ordered by the specified sortColumns. The output can be used as input to
    /// DataView.setRows() to quickly change the displayed set of rows in a visualization.
    /// 
    /// Note that the sorting is guaranteed to be stable: this means that if you sort on
    /// equal values of two rows, the same sort will return the rows in the same order every
    /// time.
    member this.getSortedRows(sortColumn: int) : int [] = X
    member this.getSortedRows(sortColumns: int []) : int [] = X
    member this.getSortedRows(sortColumn: SortType) : int [] = X
    member this.getSortedRows(sortColumns: SortType[]) : int [] = X


    /// Returns the value of a named property, or null if no such property is set for the
    /// table. The return type varies, depending on the property.
    /// 
    ///     * name is a string with the property name.
    member this.getTableProperty(name: string) : obj = X

    /// Returns the value of the cell at the given row and column indexes.
    /// 
    ///     * rowIndex should be a number greater than or equal to zero, and less than the
    ///       number of rows as returned by the getNumberOfRows() method.
    ///     * columnIndex should be a number greater than or equal to zero, and less than the
    ///       number of columns as returned by the getNumberOfColumns() method.
    /// 
    /// The type of the returned value depends on the column type (see getColumnType):
    /// 
    ///     * If the column type is 'string', the value is a string.
    ///     * If the column type is 'number', the value is a number.
    ///     * If the column type is 'boolean', the value is a boolean.
    ///     * If the column type is 'date' or 'datetime', the value is a Date object.
    ///     * If the column type is 'timeofday', the value is an array of four numbers:
    ///       [hour, minute, second, millisenconds].
    ///     * If the column value is a null value, regardless of the column type, the
    ///       returned value is null.
    member this.getValue(rowIndex: float, columnIndex: float) : obj = X

/// Represents a two-dimensional, mutable table of values. To make a read-only copy of a
/// DataTable (optionally filtered to show specific values, rows, or columns), create a
/// DataView.
/// Each column is assigned a data type, plus several optional properties including an
/// ID, label, and pattern string.
/// In addition, you can assign custom properties (name/value pairs) to any cell, row,
/// column, or the entire table. Some visualizations support specific custom properties;
/// for example the Table visualization supports a cell property called 'style', which
/// lets you assign an inline CSS style string to the rendered table cell. A
/// visualization should describe in its documentation any custom properties that it
/// supports.
[<Stub>]
[<Name "google.visualization.DataTable">]
type DataTable = 
    inherit DataCommon
    /// Creates an empty DataTable instance. Use JavaScript to populate the DataTable as
    /// shown in the following example, which creates and populates a two column, three row
    /// DataTable in JavaScript. You might use this on a page hosting a visualization to
    /// create the data for that visualization.
    new () = {}

    /// Creates a DataTable populated with the data that you pass in. You can see an example
    /// of this below.
    /// 
    /// Parameters
    /// 
    /// data
    /// 
    ///     [Required] Data used to initialize the table. This can either be the JSON
    /// returned by calling DataTable.toJSON() on a populated table, or a JavaScript object
    /// containing data used to initialize the table. The structure of the JavaScript literal
    /// object is described here.  version
    /// 
    ///     [Required] A numeric value specifying the version of the wire protocol used. The
    ///     current version is 0.6.
    /// 
    // TODO: Data can be also an object.
    new (data: string, version: float) = {}

    /// Returns a map of all properties for the specified column. Note that the properties
    /// object is returned by reference, so changing values in the retrieved object changes
    /// them in the DataTable.
    /// 
    ///     * columnIndex is the numeric index of the column to retrieve properties for.
    member this.getColumnProperties(columnIndex) : obj = X
    
    /// Adds a new column to the data table, and returns the index of the new column. All the
    /// cells of the new column are assigned a null value.
    /// 
    ///     * type should be a string with the data type of the values of the column. The
    ///       type can be one of the following: 'string' 'number' 'boolean' 'date' 'datetime'
    ///       'timeofday'.  
    ///     * label should be a string with the label of the column. The column label is 
    ///       typically displayed as part of the visualization, for example as a column header 
    ///       in a table, or as a legend label in a pie chart. If not value is specified, an 
    ///       empty string is assigned.  
    ///     * id should be a string with a unique identifier for the column. If not value is 
    ///       specified, an empty string is assigned.
    member this.addColumn(t: ColumnType) : float = X

    /// Returns a map of all properties for the specified row. Note that the properties
    /// object is returned by reference, so changing values in the retrieved object changes
    /// them in the DataTable.
    /// 
    ///     * rowIndex is the index of the row to retrieve properties for.
    member this.getRowProperties(rowIndex: float) : obj = X

    /// Adds a new column to the data table, and returns the index of the new column. All the
    /// cells of the new column are assigned a null value.
    /// 
    ///     * type should be a string with the data type of the values of the column. The
    ///       type can be one of the following: 'string' 'number' 'boolean' 'date' 'datetime'
    ///       'timeofday'.  
    ///     * label should be a string with the label of the column. The column label is 
    ///       typically displayed as part of the visualization, for example as a column header 
    ///       in a table, or as a legend label in a pie chart. If not value is specified, an 
    ///       empty string is assigned.  
    ///     * id should be a string with a unique identifier for the column. If not value is 
    ///       specified, an empty string is assigned.
    member this.addColumn(t: ColumnType, label: string) : float = X

    /// Adds a new column to the data table, and returns the index of the new column. All the
    /// cells of the new column are assigned a null value.
    /// 
    ///     * type should be a string with the data type of the values of the column. The
    ///       type can be one of the following: 'string' 'number' 'boolean' 'date' 'datetime'
    ///       'timeofday'.  
    ///     * label should be a string with the label of the column. The column label is 
    ///       typically displayed as part of the visualization, for example as a column header 
    ///       in a table, or as a legend label in a pie chart. If not value is specified, an 
    ///       empty string is assigned.  
    ///     * id should be a string with a unique identifier for the column. If not value is 
    ///       specified, an empty string is assigned.
    member this.addColumn(t: ColumnType, label: string, id: string) : float = X

    /// Adds a new row to the data table, and returns the index of the new row.
    ///     * opt_cellArray [optional] A row object, in JavaScript notation, specifying the
    ///       data for the new row. If this parameter is not included, this method will
    ///       simply add a new, empty row to the end of the table. This parameter is an array
    ///       of cell values: if you only want to specify a value for a cell, just give the
    ///       cell value (e.g., 55, 'hello'); if you want to specify a formatted value and/or
    ///       properties for the cell, you will have to use a cell objects (e.g., {v:55,
    ///       f:'Fifty-five', p:'USD'}). You can mix simple values and cell objects in the
    ///       same method call). Use null or an empty array entry for an empty cell.
    member this.addRow() : float = X

    /// Adds a new row to the data table, and returns the index of the new row.
    ///     * opt_cellArray [optional] A row object, in JavaScript notation, specifying the
    ///       data for the new row. If this parameter is not included, this method will
    ///       simply add a new, empty row to the end of the table. This parameter is an array
    ///       of cell values: if you only want to specify a value for a cell, just give the
    ///       cell value (e.g., 55, 'hello'); if you want to specify a formatted value and/or
    ///       properties for the cell, you will have to use a cell objects (e.g., {v:55,
    ///       f:'Fifty-five', p:'USD'}). You can mix simple values and cell objects in the
    ///       same method call). Use null or an empty array entry for an empty cell.
    member this.addRow(cellArray: Cell []) : float = X

    /// Adds new rows to the data table, and returns the index of the last added row. You can
    /// call this method to create new empty rows, or with data used to populate the rows, as
    /// described below.
    ///     * numOrArray - Either a number or an array:
    ///           o Number - A number specifying how many new, unpopulated rows to add.
    ///           o Array - An array of row objects used to populate a set of new rows. Each
    ///           row is an object as described in addRow(). Use null or an empty array entry
    ///           for an empty cell.
    member this.addRows(num: int) : float = X

    /// Adds new rows to the data table, and returns the index of the last added row. You can
    /// call this method to create new empty rows, or with data used to populate the rows, as
    /// described below.
    ///     * numOrArray - Either a number or an array:
    ///           o Number - A number specifying how many new, unpopulated rows to add.
    ///           o Array - An array of row objects used to populate a set of new rows. Each
    ///           row is an object as described in addRow(). Use null or an empty array entry
    ///           for an empty cell.
    member this.addRows(cells: Cell [] []) : float = X

    /// Returns a clone of the data table. The result is a deep copy of the data table except
    /// for the cell properties, row properties, table properties and column properties,
    /// which are shallow copies; this means that non-primitive properties are copied by
    /// reference, but primitive properties are copied by value
    member this.clone() : DataTable = X


    // CHECK: Does it really uses ()?
    /// Returns a map of all properties for the table.
    member this.getTableProperties() : obj = X


    /// Inserts a new column to the data table, at the specifid index. All existing columns
    /// at or after the specified index are shifted to a higher index.
    ///     * columnIndex is a number with the required index of the new column.
    ///     * type should be a string with the data type of the values of the column. The
    ///       type can be one of the following: 'string' 'number' 'boolean' 'date' 'datetime'
    ///       'timeofday'.
    ///     * label should be a string with the label of the column. The column label is
    ///       typically displayed as part of the visualization, for example as a column
    ///       header in a table, or as a legend label in a pie chart. If no value is
    ///       specified, an empty string is assigned.
    ///     * id should be a string with a unique identifier for the column. If no value is
    ///       specified, an empty string is assigned.
    member this.insertColumn(columnIndex: float, t: string) : unit = X

    /// Inserts a new column to the data table, at the specifid index. All existing columns
    /// at or after the specified index are shifted to a higher index.
    ///     * columnIndex is a number with the required index of the new column.
    ///     * type should be a string with the data type of the values of the column. The
    ///       type can be one of the following: 'string' 'number' 'boolean' 'date' 'datetime'
    ///       'timeofday'.
    ///     * label should be a string with the label of the column. The column label is
    ///       typically displayed as part of the visualization, for example as a column
    ///       header in a table, or as a legend label in a pie chart. If no value is
    ///       specified, an empty string is assigned.
    ///     * id should be a string with a unique identifier for the column. If no value is
    ///       specified, an empty string is assigned.
    member this.insertColumn(columnIndex: float, t: string, label: string) : unit = X

    /// Inserts a new column to the data table, at the specifid index. All existing columns
    /// at or after the specified index are shifted to a higher index.
    ///     * columnIndex is a number with the required index of the new column.
    ///     * type should be a string with the data type of the values of the column. The
    ///       type can be one of the following: 'string' 'number' 'boolean' 'date' 'datetime'
    ///       'timeofday'.
    ///     * label should be a string with the label of the column. The column label is
    ///       typically displayed as part of the visualization, for example as a column
    ///       header in a table, or as a legend label in a pie chart. If no value is
    ///       specified, an empty string is assigned.
    ///     * id should be a string with a unique identifier for the column. If no value is
    ///       specified, an empty string is assigned.
    member this.insertColumn(columnIndex: float, t: ColumnType, label: string, id: string) : unit = X

    /// Insert the specified number of rows at the specified row index.
    /// 
    ///     * rowIndex is the index number where to insert the new row(s). Rows will be
    ///       added, starting at the index number specified.
    /// 
    ///     * numberOrArray is either a number of new, empty rows to add, or an array of one
    ///       or more populated rows to add at the index. See addRows() for the syntax for
    ///       adding an array of row objects.
    member this.insertRows(rowIndex: float, number: float) : unit = X

    /// Insert the specified number of rows at the specified row index.
    /// 
    ///     * rowIndex is the index number where to insert the new row(s). Rows will be
    ///       added, starting at the index number specified.
    /// 
    ///     * numberOrArray is either a number of new, empty rows to add, or an array of one
    ///       or more populated rows to add at the index. See addRows() for the syntax for
    ///       adding an array of row objects.
    member this.insertRows(rowIndex: float, arr: Cell[]) : unit = X

    /// Removes the column at the specified index.
    /// 
    ///     * columnIndex should be a number with a valid column index.
    member this.removeColumn(columnIndex: float) : unit = X

    /// Removes the specified number of columns starting from the column at the specified index.
    /// 
    ///     * numberOfColumns is the number of columns to remove.
    ///     * columnIndex should be a number with a valid column index.
    member this.removeColumns(columnIndex: float, numberOfColumns: float) : unit = X

    /// Removes the row at the specified index.
    /// 
    ///     * rowIndex should be a number with a valid row index.
    member this.removeRow(rowIndex: float) : unit = X

    /// Removes the specified number of rows starting from the row at the specified index.
    /// 
    ///     * numberOfRows is the number of rows to remove.
    ///     * rowIndex should be a number with a valid row index.
    member this.removeRows(rowIndex: float, numberOfRows: float) : unit = X

    /// Sets the value, formatted value, and/or properties, of a cell.
    /// 
    ///     * rowIndex should be a number greater than or equal to zero, and less than the
    ///       number of rows as returned by the getNumberOfRows() method.
    /// 
    ///     * columnIndex should be a number greater than or equal to zero, and less than the
    ///       number of columns as returned by the getNumberOfColumns() method.
    /// 
    ///     * value [Optional] is the value assigned to the specified cell. To avoid
    ///       overwriting this value, set this parameter to undefined; to clear this value,
    ///       set it to null. The type of the value depends on the column type (see
    ///       getColumnType()):
    /// 
    ///           o If the column type is 'string', the value should be a string.
    ///           o If the column type is 'number', the value should be a number.
    ///           o If the column type is 'boolean', the value should be a boolean.
    ///           o If the column type is 'date' or 'datetime', the value should be a Date object.
    /// 
    ///           o If the column type is 'timeofday', the value should be an array of four
    ///             numbers: [hour, minute, second, millisenconds].
    /// 
    ///     * formattedValue [Optional] is a string with the value formatted as a string. To
    ///     avoid overwriting this value, set this parameter to undefined; to clear this
    ///     value and have the API apply default formatting to value as needed, set it to
    ///     null; to explicitly set an empty formatted value, set it to an empty string. The
    ///     formatted value is typically used by visualizations to display value labels. For
    ///     example the formatted value can appear as a label text within a pie chart.
    /// 
    ///     * properties [Optional] is an Object (a name/value map) with additional
    ///       properties for this cell. To avoid overwriting this value, set this parameter
    ///       to undefined; to clear this value, set it to null. Some visualizations support
    ///       row, column, or cell properties to modify their display or behavior; see the
    ///       visualization documentation to see what properties are supported.
    /// 
    member this.setCell(rowIndex: int, columnIndex: int) : unit = X

    /// Ibid
    member this.setCell(rowIndex: int, columnIndex: int, value: obj) : unit = X
    /// Ibid
    member this.setCell(rowIndex: int, columnIndex: int, value: obj, formattedValue: string) : unit = X
    /// Ibid
    member this.setCell(rowIndex: int, columnIndex: int, value: obj, formattedValue: string, properties: obj) : unit = X

    /// Sets the label of a column.
    /// 
    ///     * columnIndex should be a number greater than or equal to zero, and less than the
    ///       number of columns as returned by the getNumberOfColumns() method.
    /// 
    ///     * label is a string with the label to assign to the column. The column label is
    ///       typically displayed as part of the visualization. For example the column label
    ///       can be displayed as a column header in a table, or as the legend label in a pie
    ///       chart.
    member this.setColumnLabel(columnIndex: float, label: string) : unit = X

    /// Sets a single column property. Some visualizations support row, column, or cell
    /// properties to modify their display or behavior; see the visualization documentation
    /// to see what properties are supported.
    /// 
    ///     * columnIndex should be a number greater than or equal to zero, and less than the
    ///       number of columns as returned by the getNumberOfColumns() method.
    ///     * name is a string with the property name.
    ///     * value is a value of any type to assign to the specified named property of the
    ///       specified column.
    member this.setColumnProperty(columnIndex: float, name: string, value: obj) : unit = X

    /// Sets multiple column properties. Some visualizations support row, column, or cell
    /// properties to modify their display or behavior; see the visualization documentation
    /// to see what properties are supported.
    /// 
    ///     * columnIndex should be a number greater than or equal to zero, and less than the
    ///       number of columns as returned by the getNumberOfColumns() method.
    /// 
    ///     * properties is an Object (name/value map) with additional properties for this
    ///       column. If null is specified, all additional properties of the column will be
    ///       removed.
    member this.setColumnProperties(columnIndex: float, properties: obj) : unit = X

    /// Sets the formatted value of a cell.
    /// 
    ///     * rowIndex should be a number greater than or equal to zero, and less than the
    ///       number of rows as returned by the getNumberOfRows() method.
    /// 
    ///     * columnIndex should be a number greater than or equal to zero, and less than the
    ///       number of columns as returned by the getNumberOfColumns() method.
    /// 
    ///     * formattedValue is a string with the value formatted for display. To clear this
    ///       value and have the API apply default formatting to the cell value as needed,
    ///       set it formattedValue null; to explicitly set an empty formatted value, set it
    ///       to an empty string.
    member this.setFormattedValue(rowIndex: float, columnIndex: float, formattedValue: string) : unit = X

    /// Sets a cell property. Some visualizations support row, column, or cell properties to
    /// modify their display or behavior; see the visualization documentation to see what
    /// properties are supported.
    /// 
    ///     * rowIndex should be a number greater than or equal to zero, and less than the
    ///       number of rows as returned by the getNumberOfRows() method.
    /// 
    ///     * columnIndex should be a number greater than or equal to zero, and less than the
    ///       number of columns as returned by the getNumberOfColumns() method.
    /// 
    ///     * name is a string with the property name.
    /// 
    ///     * value is a value of any type to assign to the specified named property of the
    ///       specified cell.
    member this.setProperty(rowIndex:float , columnIndex: float, name: string, value: obj) : unit = X

    /// Sets multiple cell properties. Some visualizations support row, column, or cell
    /// properties to modify their display or behavior; see the visualization documentation
    /// to see what properties are supported.
    /// 
    ///     * rowIndex should be a number greater than or equal to zero, and less than the
    ///       number of rows as returned by the getNumberOfRows() method.
    /// 
    ///     * columnIndex should be a number greater than or equal to zero, and less than the
    ///       number of columns as returned by the getNumberOfColumns() method.
    /// 
    ///     * properties is an Object (name/value map) with additional properties for this
    ///       cell. If null is specified, all additional properties of the cell will be
    ///       removed.
    member this.setProperties(rowIndex: float, columnIndex: float, properties: obj) : unit = X

    /// Sets a row property. Some visualizations support row, column, or cell properties to
    /// modify their display or behavior; see the visualization documentation to see what
    /// properties are supported.
    /// 
    ///     * rowIndex should be a number greater than or equal to zero, and less than the
    ///       number of rows as returned by the getNumberOfRows() method.
    /// 
    ///     * name is a string with the property name.
    /// 
    ///     * value is a value of any type to assign to the specified named property of the
    ///       specified row.
    member this.setRowProperty(rowIndex: float, name: string, value: obj) : unit = X

    /// Sets multiple row properties. Some visualizations support row, column, or cell
    /// properties to modify their display or behavior; see the visualization documentation
    /// to see what properties are supported.
    /// 
    ///     * rowIndex should be a number greater than or equal to zero, and less than the
    ///       number of rows as returned by the getNumberOfRows() method.
    /// 
    ///     * properties is an Object (name/value map) with additional properties for this
    ///       row. If null is specified, all additional properties of the row will be
    ///       removed.
    member this.setRowProperties(rowIndex: float, properties: obj) : unit = X

    /// Sets a single table property. Some visualizations support table, row, column, or cell
    /// properties to modify their display or behavior; see the visualization documentation
    /// to see what properties are supported.
    /// 
    ///     * name is a string with the property name.
    ///     * value is a value of any type to assign to the specified named property of the table.
    member this.setTableProperty(name: string, value: obj) : unit = X


    /// Sets multiple table table. Some visualizations support table, row, column, or cell
    /// properties to modify their display or behavior; see the visualization documentation
    /// to see what properties are supported.
    /// 
    ///     * properties is an Object (name/value map) with additional properties for the
    ///       table. If null is specified, all additional properties of the table will be
    ///       removed.
    member this.setTableProperties(properties: obj) : unit = X

    /// Sets the value of a cell. In addition to overwriting any existing cell value, this
    /// method will also clear out any formatted value and properties for the cell.
    ///     * rowIndex should be a number greater than or equal to zero, and less than the
    ///       number of rows as returned by the getNumberOfRows() method.
    /// 
    ///     * columnIndex should be a number greater than or equal to zero, and less than the
    ///       number of columns as returned by the getNumberOfColumns() method. This method
    ///       does not let you set a formatted value for this cell; to do that, call
    ///       setFormattedValue().
    /// 
    ///     * value is the value assigned to the specified cell. The type of the returned
    ///       value depends on the column type (see getColumnType):
    /// 
    ///           o If the column type is 'string', the value should be a string.
    ///           o If the column type is 'number', the value should be a number.
    ///           o If the column type is 'boolean', the value should be a boolean.
    ///           o If the column type is 'date' or 'datetime', the value should be a Date object.
    ///           o If the column type is 'timeofday', the value should be an array of four
    ///           numbers: [hour, minute, second, millisenconds].
    ///           o For any column type, the value can be set to null.
    member this.setValue(rowIndex: int, columnIndex: int, value: obj) : unit = X

    /// Sorts the rows, according to the specified sort columns. The DataTable is modified by
    /// this method. See getSortedRows() for a description of the sorting details. This
    /// method does not return the sorted data.
    // TODO: the doc is not clear about the datatype of the arg.
    member this.sort(sortColumns: obj) : unit = X

    /// Returns a JSON representation of the DataTable that can be passed into the DataTable
    /// constructor.  Format of the Constructor's JavaScript Literal data Parameter
    member this.toJSON() : string = X

type TextStyle [<Inline "{}">] () =
    [<DefaultValue>]
    val mutable color: string
    [<DefaultValue>]
    val mutable fontName : string 
    [<DefaultValue>]
    val mutable fontSize : int

type Axis [<Inline "{}">] () =
    [<DefaultValue>]
    val mutable baseline : int

    [<DefaultValue>]
    val mutable baselineColor : string
    
    [<DefaultValue>]
    val mutable logScale : bool
    
    [<DefaultValue>]
    val mutable minValue : float
    
    [<DefaultValue>]
    val mutable maxValue : float

    /// The direction in which the values along the horizontal axis grow. Specify -1 to reverse the order of the values.
    [<DefaultValue>]
    val mutable direction : int

    /// An object that specifies the horizontal axis text style. The object has this format:
    [<DefaultValue>]
    val mutable textStyle : TextStyle
    
    /// hAxis property that specifies the title of the horizontal axis.
    [<DefaultValue>]    
    val mutable title : string

    [<DefaultValue>]
    val mutable titleTextStyle : TextStyle

    [<DefaultValue>]
    /// If true, draw the horizontal axis text at an angle, to help fit more text along the axis; if false, draw horizontal axis text upright. Default behavior is to slant text if it cannot all fit when drawn upright.
    val mutable slantedText : bool

    [<DefaultValue>]
    /// The angle of the horizontal axis text, if it's drawn slanted. Ignored if hAxis.slantedText is false, or is in auto mode, and the chart decided to draw the text horizontally.
    val mutable slantedTextAngle : float

    [<DefaultValue>]
    /// Maximum number of levels of horizontal axis text. If axis text labels become too crowded, the server might shift neighboring labels up or down in order to fit labels closer together. This value specifies the most number of levels to use; the server can use fewer levels, if labels can fit without overlapping.
    val mutable maxAlternation : float

    [<DefaultValue>]
    /// How many horizontal axis labels to show, where 1 means show every label, 2 means show every other label, and so on. Default is to try to show as many labels as possible without overlapping.
    val mutable showTextEvery : int

[<Stub>]
[<Name "google.visualization.DataView">]
type DataView = 

    inherit DataCommon

    new (data: DataCommon) = {}

    /// Returns a string representation of this DataView. This string does not contain the
    /// actual data; it only contains the DataView-specific settings such as visible rows and
    /// columns. You can store this string and pass it to the static DataView.fromJSON()
    /// constructor to recreate this view. This won't include generated columns.
    member this.toJSON() : string = X

    /// Returns the index in the underlying table (or view) of a given column specified by
    /// its index in this view. viewColumnIndex should be a number greater than or equal to
    /// zero, and less than the number of columns as returned by the getNumberOfColumns()
    /// method. Returns -1 if this is a generated column.
    member this.getTableColumnIndex(viewColumnIndex: int) : int = X

    /// Returns the index in the underlying table (or view) of a given row specified by its
    /// index in this view. viewRowIndex should be a number greater than or equal to zero,
    /// and less than the number of rows as returned by the getNumberOfRows() method.
    member this.getTableRowIndex(viewRowIndex: int) : int = X

    /// Returns the index in this view that maps to a given column specified by its index in
    /// the underlying table (or view). If more than one such index exists, returns the first
    /// (smallest) one. If no such index exists (the specified column is not in the view),
    /// returns -1. tableColumnIndex should be a number greater than or equal to zero, and
    /// less than the number of columns as returned by the getNumberOfColumns() method of the
    /// underlying table/view.
    member this.getViewColumnIndex(tableColumnIndex: int) : int = X

    /// Returns the columns in this view, in order. That is, if you call setColumns with some
    /// array, and then call getViewColumns() you should get an identical array.
    member this.getViewColumns() : int [] = X

    /// Returns the index in this view that maps to a given row specified by its index in the
    /// underlying table (or view). If more than one such index exists, returns the first
    /// (smallest) one. If no such index exists (the specified row is not in the view),
    /// returns -1. tableRowIndex should be a number greater than or equal to zero, and less
    /// than the number of rows as returned by the getNumberOfRows() method of the underlying
    /// table/view.
    member this.getViewRowIndex(tableRowIndex: int) : int = X

    /// Returns the rows in this view, in order. That is, if you call setRows with some
    /// array, and then call getViewRows() you should get an identical array.
    member this.getViewRows() : int [] = X

    /// Hides the specified columns from the current view. columnIndexes is an array of
    /// numbers representing the indexes of the columns to hide. These indexes are the index
    /// numbers in the underlying table/view. The numbers in columnIndexes do not have to be
    /// in order (that is, [3,4,1] is fine). The remaining columns retain their index order
    /// when you iterate through them. Entering an index number for a column already hidden
    /// is not an error, but entering an index that does not exist in the underlying
    /// table/view will throw an error. To unhide columns, call setColumns().
    member this.hideColumns(indexes: int []) : unit = X

    /// Hides all rows with indexes that lie between min and max (inclusive) from the current
    /// view. This is a convenience syntax for hideRows(rowIndexes) above. For example,
    /// hideRows(5, 10) is equivalent to hideRows([5, 6, 7, 8, 9, 10]).
    member this.hideRows(min: int, max: int) : unit = X

    /// Hides the specified rows from the current view. rowIndexes is an array of numbers
    /// representing the indexes of the rows to hide. These indexes are the index numbers in
    /// the underlying table/view. The numbers in rowIndexes do not have to be in order (that
    /// is, [3,4,1] is fine). The remaining rows retain their index order. Entering an index
    /// number for a row already hidden is not an error, but entering an index that does not
    /// exist in the underlying table/view will throw an error. To unhide rows, call
    /// setRows().
    member this.hideRows(rowIndexes : int []) : unit = X

    /// Specifies which columns are visible in this view. Any columns not specified will be
    /// hidden. This is an array of column indexes in the underlying table/view, or
    /// calculated columns. If you don't call this method, the default is to show all
    /// columns. The array can also contain duplicates, to show the same column multiple
    /// times. Columns will be shown in the order specified.
    /// 
    ///     * columnIndexes - An array of numbers and/or objects. Numbers are column index
    ///       values in the underlying table/view. Objects are descriptions of a calculated
    ///       column. A calculated column creates a value on the fly for each row and adds it
    ///       to the view. The object must have the following properties:
    ///           o calc [function] - A function that takes two values, the DataTable that
    ///           the view is built on, and the number of the row being generated, and
    ///           returns a single value of type type described below.
    ///           o type [string] - The JavaScript type of the value that the calc function
    ///           returns.
    ///           o label [Optional, string] - An optional label to assign to this generated
    ///           column.
    ///           o id [Optional, string] - An optional ID to assign to this generated
    ///           column.
    /// 
    /// // Column 1 is a value in centimeters, and the third column is
    /// // a generated column that converts this into inches.
    /// view.setColumns([0,1,{calc:myFunc, type:'number', label:'Height in Inches'}]);
    /// function myFunc(dataTable, rowNum){
    ///   return Math.floor(dataTable.getValue(rowNum, 1) / 2.54);
    /// }
    member this.setColumns(columnIndexes: int []) : unit = X

    /// Ibid
    member this.setColumns(columnIndexes: obj []) : unit = X

    /// Sets the rows in this view to be all indexes (in the underlying table/view) that lie
    /// between min and max (inclusive). This is a convenience syntax for setRows(rowIndexes)
    /// above. For example, setRows(5, 10) is equivalent to setRows([5, 6, 7, 8, 9, 10]).
    member this.setRows(min: int, max: int) : unit = X

    /// Sets the visible rows in this view, based on index numbers from the underlying
    /// table/view. rowIndexes should be an array of index numbers specifying which rows to
    /// show in the view. The array specifies the order in which to show the rows, and rows
    /// can be duplicated. Note that only the rows specified in rowIndexes will be shown;
    /// this method clears all other rows from the view. The array can also contain
    /// duplicates, effectively duplicating the specified row in this view (for example,
    /// setRows([3, 4, 3, 2]) will cause row 3 to appear twice in this view). The array thus
    /// provides a mapping of the rows from the underlying table/view to this view. You can
    /// use getFilteredRows() or getSortedRows() to generate input for this method.
    member this.setRows(rowIndexes: int []) : unit = X

