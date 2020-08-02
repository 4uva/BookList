# Project Summary

Developed a WPF application using C#, which imports data from a CSV file 
and displays them in a window using a `DataGrid`.

# Implementaton Details:
- a graphical user interface, consisting out of a `DataGrid` and necessary buttons for other features
- with the press of a button, the user is able to select a book list (sample list is attached Books.csv) and load it into the `DataGrid`
- Column Types:
   * “Title”, “Author”, “Price” and “Year”: text columns
   * “Binding”: combobox column
   * “In Stock”: checkbox column
   * “Description”: is not displayed directly, instead a button column is created to show the description in a tool tip when the user presses the button
- Rows with books, that are not in stock is highlighted
- The text of each cell in the “Price” column is colored according to its value (color gradient from highest to lowest price)

There a toggle button which hides all the books from DataGrid which are not in stock
