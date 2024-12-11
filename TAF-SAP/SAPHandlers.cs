using NUnit.Framework;
using sapfewse;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAF_SAP
{
    public class SAPHandlers
    {
        #region Singleton

        private static readonly SAPHandlers _instance = new SAPHandlers();
        private dynamic myKey;
        static GuiSession CurrentSession;

        private SAPHandlers()
        {
        }
        static SAPHandlers()
        {
        }
        public static SAPHandlers Instance
        {
            get
            {
                return _instance;
            }
        }

        #endregion

        #region Window

        /// <summary>
        /// Window status bar message
        /// Eventually the index will be convert to  -> wnd(0)
        /// </summary>
        /// <param name="_sapGuiSession">current Guisession </param>
        /// <param name="windowindex">index of the window 0,1,2,3.. n</param>
        /// <returns></returns>
        public string GetStatusBarMessage(GuiSession guiSession, int windowindex = 0)
        {
            if (guiSession == null)
            {
                throw new Exception("Session cannot be null");
            }

            GuiStatusbar status = guiSession.FindById<GuiStatusbar>($"wnd[{windowindex}]/sbar");
            return status.Text;
        }

        /// <summary>
        /// Get window by index
        /// Eventually the index will be convert to  -> wnd(0)
        /// </summary>
        /// <param name="_sapGuiSession">current Guisession </param>
        /// <param name="windowindex">index of the window 0,1,2,3.. n</param>
        /// <returns></returns>
        public GuiFrameWindow GetWindowByIndex(GuiSession guiSession, int windowindex = 0)
        {
            if (guiSession == null)
            {
                throw new Exception("Session cannot be null");
            }

            GuiFrameWindow window = guiSession.FindById<GuiFrameWindow>($"wnd[{windowindex}]");
            return window;
        }

        public GuiFrameWindow SetToNextWindow(GuiFrameWindow currentwindow, GuiSession session = null)

        {

            if (session == null)
                session = SAPDriver.Instance.GetSession();

            int index = Convert.ToInt32(currentwindow.Name.Split(new string[] { "wnd[" }, StringSplitOptions.RemoveEmptyEntries)[0].Split(']')[0]);
            return SAPHandlers.Instance.GetWindowByIndex(session, index + 1);
        }

        public GuiFrameWindow SetToPreviousWindow(GuiFrameWindow currentwindow, GuiSession session = null)

        {
            if (session == null)
                session = SAPDriver.Instance.GetSession();
            int index = Convert.ToInt32(currentwindow.Name.Split(new string[] { "wnd[" }, StringSplitOptions.RemoveEmptyEntries)[0].Split(']')[0]);
            return SAPHandlers.Instance.GetWindowByIndex(session, index - 1);

        }

        public GuiSession SetToNextSession(GuiSession session)
        {

            int index = Convert.ToInt32(session.Name.Split(new string[] { "ses[" }, StringSplitOptions.RemoveEmptyEntries)[0].Split(']')[0]);
            return SAPDriver.Instance.GetSession(index + 1);

        }

        public GuiSession SetToPreviousSession(GuiSession session)

        {

            int index = Convert.ToInt32(session.Name.Split(new string[] { "ses[" }, StringSplitOptions.RemoveEmptyEntries)[0].Split(']')[0]);
            return SAPDriver.Instance.GetSession(index - 1);

        }

        public GuiFrameWindow SwitchToWindowWithTitle(string Title, GuiSession session = null)

        {
            if (session == null)
                session = SAPDriver.Instance.GetSession();

            for (int index = 0; index < session.Children.Count; index++)
            {
                if (GetWindowTitle(session, index).ToUpper().Trim().Contains(Title))
                {
                    return SAPHandlers.Instance.GetWindowByIndex(session, index);

                }
            }

            Assert.Fail("Window with name" + Title + "is not found in current session");
            return null;

        }





        public string GetWindowTitle(GuiSession guiSession, int windowindex = 0)
        {
            if (guiSession == null)
            {
                throw new Exception("Session cannot be null");
            }

            GuiTitlebar title = guiSession.FindById<GuiTitlebar>($"wnd[{windowindex}]/titl");
            return title.Text;
        }

        #endregion

        #region SendKeys

        /// <summary>
        /// Send keys to a window
        /// Eventually the index will be convert to  -> wnd(0)
        /// </summary>
        /// <param name="guiSession">current Guisession </param>
        /// <param name="sAPKeys">object is SAPKeys</param>
        /// <param name="windowindex">index of the window 0,1,2,3.. n</param>
        public void SendKeysByWindow(GuiSession guiSession, SAPKeys sAPKeys, int windowindex = 0)
        {
            if (guiSession == null)
            {
                throw new Exception("Session cannot be null");
            }
            GuiFrameWindow window = guiSession.FindById<GuiFrameWindow>($"wnd[{windowindex}]");
            window.SendKey(sAPKeys);
        }

        /// <summary>
        /// SendKeyToGuiFrameWindow
        /// </summary>
        /// <param name="Window">GuiFrameWindow</param>
        /// <param name="key">object is SAPKeys</param>
        public static void SendKeyToGuiFrameWindow(GuiFrameWindow Window, SAPKeys key)
        {
            if (Window == null)
            {
                throw new Exception("Window cannot be null");
            }
            Window.SendVKey((int)key);
        }
        /// <summary>
        /// SendKeyToGuiMainWindow
        /// </summary>
        /// <param name="Window">GuiMainWindow</param>
        /// <param name="key">object is SAPKeys</param>
        public static void SendKeyToGuiMainWindow(GuiMainWindow Window, SAPKeys key)
        {
            if (Window == null)
            {
                throw new Exception("Window cannot be null");
            }
            Window.SendVKey((int)key);
        }
        /// <summary>
        /// SendKeyToGuiModalWindow
        /// </summary>
        /// <param name="Window">GuiModalWindow</param>
        /// <param name="key">object is SAPKeys</param>
        public static void SendKeyToGuiModalWindow(GuiModalWindow Window, SAPKeys key)
        {
            if (Window == null)
            {
                throw new Exception("Window cannot be null");
            }
            Window.SendVKey((int)key);
        }

        #endregion

        #region Treeview 
        /// <summary>
        /// This will select and expand a node with a specified code (fastest way)
        /// </summary>
        /// <param name="tree">Treeview object</param>
        /// <param name="code">Code of the node</param>
        public void ExpandTreeNodeByCode(GuiTree tree, string code)
        {
            if (tree == null)
            {
                throw new Exception("tree cannot be null");
            }
            tree.SetFocus();
            tree.SelectNode(code);
            tree.ExpandNode(code);
        }

        /// <summary>
        /// This will select and doubleclick a node with a specified code (fastest way)
        /// </summary>
        /// <param name="tree">Treeview object</param>
        /// <param name="code">Code of the node</param>
        public void SelectTreeNodeByCode(GuiTree tree, string node)
        {
            if (tree == null)
            {
                throw new Exception("tree cannot be null");
            }
            tree.SetFocus();
            tree.SelectNode(node);
            tree.DoubleClickNode(node);
        }
        /// <summary>
        /// This will retrun a specific element in tree 
        /// /// </summary>
        /// <param name="tree">Treeview object</param>
        /// <param name="text">text from node</param>
        public dynamic GetTreeNodeText(GuiTree tree, String text)
        {

            foreach (var key in tree.GetAllNodeKeys())
            {
                var node = tree.GetNodeTextByKey(key);


                if (node.ToLower().Trim().Contains(text.ToLower().Trim()))
                {
                    myKey = node.ToLower();
                    break;
                }
            }
            return myKey;
        }


        /// <summary>
        /// This will select and expand a node. A quick selection of node if it is inside hierarchy of folders
        /// path-> Folder1~Folder2~Foldern~node text
        /// </summary>
        /// <param name="tree">Treeview object</param>
        /// <param name="path">path of the node</param>
        public void ExpandTreeNodeByPath(GuiTree tree, string path)
        {
            if (tree == null)
            {
                throw new Exception("tree cannot be null");
            }
            tree.SetFocus();
            string key = tree.GetTreeNodeKeyFromPath(path);
            tree.SelectNode(key);
            tree.DoubleClickNode(key);
        }

        /// <summary>
        /// This will select and double click a node. A quick selection of node if it is inside hierarchy of folders
        /// path-> Folder1~Folder2~Foldern~node text
        /// </summary>
        /// <param name="tree">Treeview object</param>
        /// <param name="path">path of the node</param>
        public void SelectTreeNodeByPath(GuiTree tree, string path)
        {
            if (tree == null)
            {
                throw new Exception("tree cannot be null");
            }
            tree.SetFocus();
            string key = tree.GetTreeNodeKeyFromPath(path);
            tree.SelectNode(key);
            tree.DoubleClickNode(key);
        }

        /// <summary>
        /// This will select and expand a node. This will take time as it finds the node with a text
        /// text-> node text
        /// </summary>
        /// <param name="tree">Treeview object</param>
        /// <param name="text">text of the node</param>
        public void ExpandTreeNodeByText(GuiTree tree, string text)
        {
            if (tree == null)
            {
                throw new Exception("tree cannot be null");
            }
            tree.SetFocus();
            string key = tree.GetTreeNodeKeyFromText(text);
            tree.SelectNode(key);
            tree.DoubleClickNode(key);
        }

        /// <summary>
        /// This will select and doubleclick a node. This will take time as it finds the node with a text
        /// text-> node text
        /// </summary>
        /// <param name="tree">Treeview object</param>
        /// <param name="text">text of the node</param>
        public string SelectTreeNodeByText_ReturnKey(GuiTree tree, string text)
        {
            if (tree == null)
            {
                throw new Exception("tree cannot be null");
            }
            tree.SetFocus();
            string key = tree.GetTreeNodeKeyFromText(text);
            if (key != "")
            {
                tree.SelectNode(key);
                tree.DoubleClickNode(key);
            }
            return key;
        }

        public void SelectTreeNodeByText(GuiTree tree, string text)
        {
            if (tree == null)
            {
                throw new Exception("tree cannot be null");
            }
            tree.SetFocus();
            string key = tree.GetTreeNodeKeyFromText(text);
            tree.SelectNode(key);
            tree.DoubleClickNode(key);

        }
        #endregion Treeview



        #region Button
        /// <summary>
        /// focus a button and click
        /// </summary>
        /// <param name="btn">button object</param>
        public void ClickButton(GuiButton btn)
        {
            if (btn == null)
            {
                throw new Exception("btn cannot be null");
            }
            btn.SetFocus();
            btn.Press();
        }

        public bool isButtonEnabled(GuiButton btn)
        {
            if (btn.Changeable)
                return true;
            else
                return false;
        }

        #endregion Button

        #region GuiTextField
        /// <summary>
        /// enter text on a GUITextField type control
        /// </summary>
        /// <param name="txt">GUITextField</param>
        /// <param name="value">text to enter</param>
        public void EnterTextInGuiTextField(GuiTextField txt, string value)
        {
            if (txt == null)
            {
                throw new Exception("txt cannot be null");
            }
            
            txt.SetFocus();
            txt.Text = value.Trim();
            txt.CaretPosition = value.Trim().Length;
        }
        /// <summary>
        /// get text on a GUITextField type control
        /// </summary>
        /// <param name="txt">GUITextField</param> 
        public string GetTextFromGuiTextField(GuiTextField txt)
        {
            if (txt == null)
            {
                throw new Exception("txt cannot be null");
            }
            txt.SetFocus();
            return txt.Text.Trim();
        }

        #endregion

        #region GuiOkCodeField
        /// <summary>
        /// enter text on a GuiOkCodeField type control
        /// </summary>
        /// <param name="txt">GUITextField</param>
        /// <param name="value">text to enter</param>
        public void EnterTextInGuiOkCodeField(GuiOkCodeField txt, string value)
        {
            if (txt == null)
            {
                throw new Exception("txt cannot be null");
            }
            txt.SetFocus();
            txt.Text = value.Trim();
        }
        /// <summary>
        /// enter text on a GuiOkCodeField type control
        /// </summary>
        /// <param name="txt">GUITextField</param>
        public string GetTextFromGuiOkCodeField(GuiOkCodeField txt)
        {
            if (txt == null)
            {
                throw new Exception("txt cannot be null");
            }
            txt.SetFocus();
            return txt.Text.Trim();
        }
        #endregion

        #region GuiToolbarControl

        public void ClickToolbar(GuiToolbarControl tbarControl, string id)
        {
            if (tbarControl == null)
            {
                throw new Exception("Toolbar control cannot be null");
            }
            tbarControl.PressButton(id);
         }

        public void ClickToolbarMenu(GuiToolbarControl tbarControl, string id)
        {
            if (tbarControl == null)
            {
                throw new Exception("Toolbar control cannot be null");
            }
            tbarControl.PressContextButton(id);
            tbarControl.SelectContextMenuItem(id);
        }

        #endregion

        #region GuiTextedit
        /// <summary>
        /// enter text on a GuiOkCodeField type control
        /// </summary>
        /// <param name="txt">GuiTextedit</param>
        /// <param name="value">text to enter</param>
        public void EnterTextInGuiTextedit(GuiTextedit txt, string value)
        {
            if (txt == null)
            {
                throw new Exception("txt cannot be null");
            }
            txt.SetFocus();
            txt.Text = value.Trim();
        }

        /// <summary>
        /// enter text on a GuiOkCodeField type control
        /// </summary>
        /// <param name="txt">GuiTextedit</param> 
        public string GetTextFromGuiTextedit(GuiTextedit txt)
        {
            if (txt == null)
            {
                throw new Exception("txt cannot be null");
            }
            txt.SetFocus();
            return txt.Text.Trim();
        }
        #endregion

        #region GUIGridView

        /// <summary>
        /// GetGridviewTextByRowColumn
        /// </summary>
        /// <param name="grd">Gridview</param>
        /// <param name="row">index of row</param>
        /// <param name="column">index of column</param>
        /// <returns></returns>
        public string GetGridviewTextByRowColumn(GuiGridView grd, int row, int column)
        {
            if (grd == null)
            {
                throw new Exception("grid cannot be null");
            }
            return grd.GetCellValue(column, row);
        }

        /// <summary>
        /// DoubleClickOnAGridViewCellByColumnName
        /// </summary>
        /// <param name="grd">Gridview</param>
        /// <param name="row">index of row</param>
        /// <param name="columnTitle">display name of column</param>
        /// <returns></returns>
        public void DoubleClickOnAGridViewCellByColumnName(GuiGridView grd, int row, string columnTitle)
        {
            if (grd == null)
            {
                throw new Exception("grid cannot be null");
            }
            //string columnName = GridViewColumnNameFromDisplayedName(grd, columnTitle);
            //if (string.IsNullOrEmpty(columnName))
            //{
            //    throw new Exception($"Column with title {columnTitle} not found");
            //}

            //grd.DoubleClickCell(row, columnName);
            grd.DoubleClickCell(row, columnTitle);
        }


        public  void ClickCell(GuiGridView GridView, int row, string FriendlyColumn)
        {
            string column = "";
            GridView.SelectAll();
            foreach (var colName in GridView.SelectedColumns)
            {
                string displayCol = GridView.GetDisplayedColumnTitle(colName);
                if (displayCol.IndexOf(FriendlyColumn) >= 0)
                {
                    column = colName;
                    break;
                }

            }
            GridView.ClearSelection();
            GridView.CurrentCellColumn = column;
            GridView.SelectedRows = row.ToString();
            GridView.SetCurrentCell(row, column);
            GridView.ClickCurrentCell();
        }
        /// <summary>
        /// GetGridviewTextByRowColumn
        /// </summary>
        /// <param name="grd">Gridview</param>
        /// <param name="row">index of row</param>
        /// <param name="column">index of column</param>
        /// <returns></returns>
        public string GetGridviewTextByRowColumnHeader(GuiGridView grd, int row, string columnTitle)
        {
            if (grd == null)
            {
                throw new Exception("grid cannot be null");
            }
            return grd.GetCellValueByDisplayColumn(row, columnTitle);
        }

        public void GridSelectAllRows(GuiGridView grd)
        {
            if (grd == null)
            {
                throw new Exception("grid cannot be null");
            }
            grd.SelectAll();
        }
        public int GridGetRowCount(GuiGridView grd)
        {
            if (grd == null)
            {
                throw new Exception("grid cannot be null");
            }
            grd.SelectAll();
            int rowCount = grd.VisibleRowCount;
            
            return rowCount;
        }

        /// <summary>
        /// GetGridviewTextByRowColumn
        /// </summary>
        /// <param name="grd">Gridview</param>
        /// <param name="txt">text to find</param> 
        public dynamic GetGridviewCellByValue(GuiGridView grd, string cellvalue)
        {
            if (grd == null)
            {
                throw new Exception("grid cannot be null");
            }
            int rowCount = grd.VisibleRowCount;
            int selectedRow = 0;
            int selectedColumn = 0;

            grd.SelectAll();
            for (int rowindex = 0; rowindex < rowCount; rowindex++)
            {
                int columnIndex = 0;
                foreach (var colName in grd.SelectedColumns)
                {
                    string value = grd.GetCellValue(rowindex, colName);
                    if (value.ToString().Trim().Equals(cellvalue))
                    {
                        selectedRow = rowindex;
                        selectedColumn = columnIndex;
                        goto found;
                    }
                    columnIndex++;
                }
            }

        found:
            grd.ClearSelection();

            return new
            {
                Row = selectedRow,
                Column = selectedColumn
            };
        }

        public void FilterGridviewColumn(GuiGridView grd, string columnTitle)
        {

            if (grd == null)
            {
                throw new Exception("grid cannot be null");
            }
            string columnName = GridViewColumnNameFromDisplayedName(grd, columnTitle);
            if (string.IsNullOrEmpty(columnName))
            {
                throw new Exception($"Column with title {columnTitle} not found");
            }

            grd.SelectColumn(columnName);
            grd.PressToolbarContextButton("&MB_FILTER");
            grd.SelectContextMenuItem("&FILTER");

           
        }

        public void selectMenuOption(GuiGridView grd, String id, String menuOption)
        {
            if (grd == null)
            {
                throw new Exception("grid cannot be null");
            }
            grd.PressToolbarContextButton(id);
            grd.SelectContextMenuItem(menuOption);

        }

        public void selectToolbarItem(GuiToolbar tbar)
        {
            // tbar
        }
        public void GridviewSelectFilterCondition(GuiGridView grd, string columnTitle, string filter)
        {
            if (grd == null)
            {
                throw new Exception("grid cannot be null");
            }
            // grd.PressToolbarContextButton("&MB_FILTER");
            //grd.SelectContextMenuItem("&FILTER");
            FilterGridviewColumn(grd, columnTitle);


        }

        public void RemoveFilterGridviewColumn(GuiGridView grd)
        {
            if (grd == null)
            {
                throw new Exception("grid cannot be null");
            }
            grd.PressToolbarContextButton("&MB_FILTER");
            grd.SelectContextMenuItem("&DELETE_FILTER");
        }

        public void GridSetCurrentCell(GuiGridView grd, int row, string column)
        {
            if (grd == null)
            {
                throw new Exception("grid cannot be null");
            }

            grd.SetCurrentCell(row, column);
        }

        public void GridPressToolBar(GuiGridView grd, string id)
        {
            if (grd == null)
            {
                throw new Exception("grid cannot be null");
            }

            grd.PressToolbarButton(id);
        }
        /// <summary>
        /// GetFilteredRowsByValues - get gridview in a table format
        /// slow process as it need to go through all the columns and rows 
        /// predicate sampel - x => x.Field<string>(column title1) == "XY" && x.Field<string>(column title2)=="ABC"
        /// </summary>
        /// <param name="grd">gridview </param>
        /// <param name="predicate">Linq function</param>
        /// <returns>syste.data.datatable</returns>
        public DataTable GetFilteredRowsByCellValues(GuiGridView grd, Func<DataRow, bool> predicate)
        {
            if (grd == null)
            {
                throw new Exception("grid cannot be null");
            }

            DataTable dt = new DataTable();

            grd.SelectAll();

            string firstColumn = string.Empty;
            foreach (var colName in grd.SelectedColumns)
            {
                string displayCol = grd.GetDisplayedColumnTitle(colName);
                dt.Columns.Add(displayCol);

                if (firstColumn == string.Empty)
                    firstColumn = colName;
            }

            for (int rowindex = 0; rowindex < grd.RowCount; rowindex++)
            {
                if (rowindex >= 34)
                    // GridSetCurrentCell(grd, rowindex, firstColumn);
                    grd.SetCurrentCell(rowindex, grd.FirstVisibleColumn);

                DataRow dRow = dt.NewRow();
                foreach (DataColumn col in dt.Columns)
                {
                    dRow[col.ColumnName] = GetGridviewTextByRowColumnHeader(grd, rowindex, col.ColumnName);
                }
                dt.Rows.Add(dRow);
            }

            grd.ClearSelection();

            return ExecuteInContext(dt, predicate);

        }

        private string GridViewColumnNameFromDisplayedName(GuiGridView grd, string displayedColumnName)
        {
            if (grd == null)
            {
                throw new Exception("grid cannot be null");
            }
            grd.SelectAll();
            foreach (var colName in grd.SelectedColumns)
            {
                string displayCol = grd.GetDisplayedColumnTitle(colName);
                if (displayCol.Trim().ToLower().Equals(displayedColumnName.Trim().ToLower()))
                {
                    grd.ClearSelection();
                    return colName;
                }
            }


            grd.ClearSelection();

            return string.Empty;
        }

        private static DataTable ExecuteInContext(DataTable src, Func<DataRow, bool> predicate)
        {
            var data = src.AsEnumerable();
            var dataTables = data.Where(predicate);
            return dataTables.CopyToDataTable();
        }

        public void EnterTextGridField(GuiGridView grd, int row, string column, string text)
        {
            string columnName = GridViewColumnNameFromDisplayedName(grd, column);

            string cellType = grd.GetCellType(row, columnName);

            switch (cellType)
            {
                case "Normal":
                    grd.ModifyCell(row, columnName, text);
                    break;
                case "Button":
                    grd.Click(row, columnName);
                    break;
                case "ValueList":
                    break;

            }
        }

        public void ClickGridField(GuiGridView grd, int row, string column)
        {
            string columnName = GridViewColumnNameFromDisplayedName(grd, column);

            string cellType = grd.GetCellType(row, columnName);

            grd.Click(row, columnName);
        }

        public void SelectTextGridField(GuiGridView grd, int row, string column, bool value)
        {
            string columnName = GridViewColumnNameFromDisplayedName(grd, column);

            string cellType = grd.GetCellType(row, columnName);

            switch (cellType)
            {
                case "Checkbox":
                    grd.ModifyCheckBox(row, columnName, value);
                    break;
                case "RadioButton":

                    break;
            }
        }


        #endregion

        #region GUICheckbox

        /// <summary>
        /// IsCheckboxSelected -  returns true or false based on the state of the checkbox
        /// </summary>
        /// <param name="chk"></param>
        /// <returns></returns>
        public bool IsCheckboxSelected(GuiCheckBox chk)
        {
            if (chk == null)
            {
                throw new Exception("checkbox cannot be null");
            }
            return chk.Selected;
        }


        /// <summary>
        /// SelectCheckbox -  chnages state of a checkbox to 'selected' or 'unselected'
        /// </summary>
        /// <param name="chk"></param>
        /// <param name="select">true or false</param>
        /// <returns></returns>
        public void SelectCheckbox(GuiCheckBox chk, bool select)
        {
            if (chk == null)
            {
                throw new Exception("checkbox cannot be null");
            }
            chk.Selected = select;
        }

        #endregion

        #region GuiRadioButton

        /// <summary>
        /// Isradiobutton selected -  returns true or false based on the state of the radio button
        /// </summary>
        /// <param name="rdo"></param>
        /// <returns></returns>
        public bool IsRadioButtonSelected(GuiRadioButton rdo)
        {
            if (rdo == null)
            {
                throw new Exception("RadioButton cannot be null");
            }
            return rdo.Selected;
        }

        /// <summary>
        /// GuiRadioButton -  chnages state of a radiobutton to 'selected' or 'unselected'
        /// </summary>
        /// <param name="chk"></param>
        /// <param name="select">true or false</param>
        /// <returns></returns>
        public void SelectRadioButton(GuiRadioButton rdo, bool select)
        {
            if (rdo == null)
            {
                throw new Exception("RadioButton cannot be null");
            }
            rdo.Selected = select;
        }

        #endregion

        #region GuiComboBox
        /// <summary>
        /// SelectComboboxItemByIndex
        /// index - if 3 items are thre index is starting from 0 to 2
        /// </summary>
        /// <param name="cmb"></param>
        /// <param name="index">index of the item </param>
        public void SelectComboboxItemByIndex(GuiComboBox cmb, int index)
        {
            if (cmb == null)
            {
                throw new Exception("GuiComboBox cannot be null");
            }

            cmb.SetFocus();
            GuiCollection collection = cmb.Entries;
            int length = collection.Length;

            if (index > length - 1)
            {
                throw new Exception("Index greater than count of items");
            }

            string key = collection.Item(index).Key as string;
            SetComboboxKey(cmb, key);
        }

        /// <summary>
        /// SelectComboboxItemByText
        /// </summary>
        /// <param name="cmb"></param>
        /// <param name="index">text in the items collection </param>
        public void SelectComboboxItemByKey(GuiComboBox cmb, string _key)
        {
            if (cmb == null)
            {
                throw new Exception("GuiComboBox cannot be null");
            }

            string currentKey = GetComboboSelectedKey(cmb);
            if (currentKey.Equals(_key))
            {
                return;
            }

            cmb.SetFocus();
            GuiCollection collection = cmb.Entries;
            int length = collection.Length;
            string key = string.Empty;

            for (int indx = 0; indx < length; indx++)
            {
                key = collection.Item(indx).Key as string;
                if (key.Trim().ToLower().Equals(_key.ToLower()))
                {
                    break;
                }
            }
            SetComboboxKey(cmb, key);
        }

        public void SelectComboboxItemByValue(GuiComboBox cmb, string _value)
        {
            if (cmb == null)
            {
                throw new Exception("GuiComboBox cannot be null");
            }

            string currentSelection = GetComboboSelectedText(cmb);
            if (currentSelection.Equals(_value))
            {
                return;
            }

            cmb.SetFocus();
            GuiCollection collection = cmb.Entries;
            int length = collection.Length;
            string value = string.Empty;
            string key = string.Empty;

            for (int indx = 0; indx < length; indx++)
            {
                value = collection.Item(indx).Value as string;
                if (value.Trim().ToLower().Equals(_value.ToLower()))
                {
                    key = collection.Item(indx).Key as string;
                    break;
                }
            }
            SetComboboxKey(cmb, key);
        }

        /// <summary>
        /// GetComboboSelectedValue - current selected
        /// </summary>
        /// <param name="cmb"></param> 
        public string GetComboboSelectedValue(GuiComboBox cmb)
        {
            if (cmb == null)
            {
                throw new Exception("GuiComboBox cannot be null");
            }

            cmb.SetFocus();
            return cmb.Value.Trim();
        }
        /// <summary>
        /// GetComboboSelectedText - current selected
        /// </summary>
        /// <param name="cmb"></param>
        public string GetComboboSelectedText(GuiComboBox cmb)
        {
            if (cmb == null)
            {
                throw new Exception("GuiComboBox cannot be null");
            }

            cmb.SetFocus();
            return cmb.Text.Trim();
        }

        /// <summary>
        /// GetComboboSelectedKey - current selected
        /// </summary>
        /// <param name="cmb"></param>
        public string GetComboboSelectedKey(GuiComboBox cmb)
        {
            if (cmb == null)
            {
                throw new Exception("GuiComboBox cannot be null");
            }

            cmb.SetFocus();
            return cmb.Key.Trim();
        }

        private void SetComboboxKey(GuiComboBox cmb, string key)
        {
            if (cmb == null)
            {
                throw new Exception("GuiComboBox cannot be null");
            }
            cmb.Key = key.Trim();
        }

        #endregion

        #region GUITable

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tbl"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public string GetTableCellValueByRowColumnTitle(GuiTableControl tbl, int row, string column)
        {
            int columnIndex = GetColumnIndexByTitle(tbl, column);
            return GetTableCellValueByRowColumn(tbl, row, columnIndex);
        }

        /// <summary>
        /// GetTableCellValueByRowColumn
        /// </summary>
        /// <param name="grd">GuiTableControl</param>
        /// <param name="row">index of row</param>
        /// <param name="column">index of column</param>
        /// <returns></returns>
        public string GetTableCellValueByRowColumn(GuiTableControl tbl, int row, int column)
        {
            if (tbl == null)
            {
                throw new Exception("GuiTableControl cannot be null");
            }
            return tbl.GetCell(row, column).Text;
        }
        /// <summary>
        /// GetTableCellValueByCellValue
        /// </summary>
        /// <param name="grd">GuiTableControl</param>
        /// <param name="cellvalue">text to search</param> 
        /// <returns></returns>
        public dynamic GetTableCellValueByCellValue(GuiTableControl tbl, string cellvalue)
        {
            if (tbl == null)
            {
                throw new Exception("GuiTableControl cannot be null");
            }

            int rowCount = tbl.VisibleRowCount;
            int columnCount = tbl.Columns.Length;
            //GuiCollection collection = tbl.Columns;
            //for (int columnIndex = 0; columnIndex < collection.Length; columnIndex++)
            //{
            //    int width = collection.Item(columnIndex).Width;

            //    if (width > 0)
            //    {
            //        columnCount++;
            //    }
            //}

            int selectedRow = 0;
            int selectedColumn = 0;


            for (int rowindex = 0; rowindex < rowCount; rowindex++)
            {
                for (int columnIndex = 1; columnIndex < columnCount; columnIndex++)
                {
                    string value = GetTableCellValueByRowColumn(tbl, rowindex, columnIndex);
                    if (value.ToString().Trim().Equals(cellvalue))
                    {
                        selectedRow = rowindex;
                        selectedColumn = columnIndex;
                        goto found;
                    }

                }
            }

        found:

            return new
            {
                Row = selectedRow,
                Column = selectedColumn
            };
        }
        public DataTable FilterTableByRowValue(GuiTableControl tbl, Func<DataRow, bool> predicate)
        {
            if (tbl == null)
            {
                throw new Exception("GuiTableControl cannot be null");
            }

            DataTable dt = new DataTable();

            for (int columnIndex = 0; columnIndex < tbl.Columns.Count; columnIndex++)
            {
                string displayCol = tbl.Columns.Item(columnIndex).Title;
                dt.Columns.Add(displayCol);
            }

            for (int rowindex = 0; rowindex < tbl.Rows.Count; rowindex++)
            {
                DataRow dRow = dt.NewRow();

                GuiTableRow guitablerow = tbl.Rows.Item(rowindex);
                for (int columnIndex = 1; columnIndex < guitablerow.Length; columnIndex++)
                {
                    if (guitablerow.Item(columnIndex).Type == "GuiCTextField")
                    {
                        GuiCTextField guiCTextField = (GuiCTextField)guitablerow.Item(columnIndex);
                        dRow[columnIndex] = guiCTextField.Text;
                    }

                    else if (guitablerow.Item(columnIndex).Type == "GuiTextField")
                    {
                        GuiTextField guiCTextField = (GuiTextField)guitablerow.Item(columnIndex);
                        dRow[columnIndex] = guiCTextField.Text;
                    }
                    else
                    {
                        dRow[columnIndex] = "";
                    }
                }
                dt.Rows.Add(dRow);
            }

            return ExecuteInContext(dt, predicate);
        }
        public void EnterTextTableField(GuiTableControl tbl, int row, string column, string text)
        {
            int columnIndex = GetColumnIndexByTitle(tbl, column);

            EnterTextTableField(tbl, row, columnIndex, text);
        }
        public void EnterTextTableField(GuiTableControl tbl, int row, int column, string text)
        {
            GuiVComponent cell = tbl.GetCell(row, column);

            switch (cell.Type)
            {
                case "GuiTextField":
                    EnterTextInGuiTextField(cell as GuiTextField, text);
                    break;
                case "GuiOkCodeField":
                    EnterTextInGuiOkCodeField(cell as GuiOkCodeField, text);
                    break;
                case "GuiTextedit":
                    EnterTextInGuiTextedit(cell as GuiTextedit, text);
                    break;
                case "GuiCTextField":
                    EnterTextInGuiCTextField(cell as GuiCTextField, text);
                    break;
            }
        }
        public void SelectTableCellCheckBox(GuiTableControl tbl, int row, string column, bool value)
        {
            int columnIndex = GetColumnIndexByTitle(tbl, column);

            SelectTableCellCheckBox(tbl, row, columnIndex, value);
        }
        public void SelectTableCellCheckBox(GuiTableControl tbl, int row, int column, bool value)
        {
            GuiVComponent cell = tbl.GetCell(row, column);

            switch (cell.Type)
            {
                case "GuiCheckBox":
                    if (!IsCheckboxSelected(cell as GuiCheckBox))
                    {
                        SelectCheckbox(cell as GuiCheckBox, value);
                    }
                    break;
            }
        }
        private int GetColumnIndexByTitle(GuiTableControl tbl, string column)
        {
            int columnIndex = -1;
            GuiCollection guiCollection = tbl.Columns;
            int columnCount = guiCollection.Length;

            for (int i = 0; i < columnCount; i++)
            {
                GuiTableColumn guiTableColumn = guiCollection.Item(i) as GuiTableColumn;
                if (guiTableColumn.Title.Trim().Equals(column))
                {
                    columnIndex = i;
                    break;
                }
                else if (guiTableColumn.Tooltip.Trim().Equals(column))
                {
                    columnIndex = i;
                    break;
                }
            }

            if (columnIndex < 0)
            {
                throw new Exception("Column cannot be found");
            }

            return columnIndex;
        }

        #endregion

        #region GUILabel

        public void SelectLabel(GuiLabel lbl)
        {
            if (lbl == null)
            {
                throw new Exception("GuiLabel cannot be null");
            }

            lbl.SetFocus();
            lbl.CaretPosition = lbl.Text.Trim().Length;
        }

        public string GetLabelText(GuiLabel lbl)
        {
            if (lbl == null)
            {
                throw new Exception("GuiLabel cannot be null");
            }

            lbl.SetFocus();
            return lbl.Text.Trim();
        }

        public GuiLabel FindLabelInsideUserArea(GuiUserArea guiUserArea, string labelText)
        {
            if (guiUserArea == null)
            {
                throw new Exception("guiUserArea cannot be null");
            }


            GuiComponentCollection collection = FindAllControlsInsideUserArea(guiUserArea);
            if (collection == null)
            {
                return null;
            }

            for (int i = 0; i < collection.Length; i++)
            {
                GuiComponent component = collection.Item(i);
                if (component.Type.Equals("GuiLabel"))
                {
                    GuiLabel lbl = (GuiLabel)component;
                    if (lbl.Text.Trim().ToLower().Equals(labelText.ToLower()))
                    {
                        return lbl;
                    }
                }
            }
            return null;
        }

        #endregion

        #region UserArea
        public GuiComponentCollection FindAllControlsInsideUserArea(GuiUserArea guiUserArea)
        {
            if (guiUserArea == null)
            {
                throw new Exception("guiUserArea cannot be null");
            }

            GuiComponentCollection collection = null;

            collection = guiUserArea.Children;

            if (collection.Length == 0)
            {
                return null;
            }
            else
            {
                return collection;
            }
        }

        #endregion

        #region string comparison

        public bool VerifyTextEquals(String strActualText, String strCompText)
        {
            bool bVerifyText = false;

            try
            {
                bVerifyText = CompareText(strActualText, strCompText);
                if (!bVerifyText)
                {
                    Console.Write(strActualText + " doesnot match with " + strCompText);
                    Assert.Fail(strActualText + " doesnot match with " + strCompText);
                }

            }
            catch (Exception e)
            {
                string msg = ("Error while performing the VerifyText action Exception :" + e);
                Console.Write(msg);
                Assert.Fail(msg);
            }
            return bVerifyText;
        }

        public bool VerifyTextContains(String strActualText, String strCompText)
        {
            bool bVerifyText = false;

            try
            {
                bVerifyText = ContainsText(strActualText, strCompText);
                if (!bVerifyText)
                {
                    Console.Write(strActualText + " doesnot contain " + strCompText);
                    Assert.Fail(strActualText + " doesnot contain " + strCompText);
                }
            }
            catch (Exception e)
            {
                string msg = ("Error while performing the VerifyText action Exception :" + e);
                Console.Write(msg);
                Assert.Fail(msg);
            }
            return bVerifyText;
        }

        public bool CompareText(String strActualText, String strCompText)
        {
            bool compFlag = false;
            try
            {
                if (strActualText.Trim().Equals(strCompText.Trim()))
                {
                    compFlag = true;
                }
                else
                {
                    compFlag = false;
                    Console.Write(strActualText + " doesnot match with " + strCompText);
                }
            }
            catch (Exception e)
            {
                string msg = ("Error occurred while doing the compareText action " + "Exception :" + e);
                Console.Write(msg);
                Assert.Fail(msg);
            }
            return compFlag;
        }

        public bool CompareObject<T>(T objA, T objB, string customMessage)
        {
            bool compFlag = false;
            try
            {
                if (objA.Equals(objB))
                {
                    compFlag = true;
                }
                else
                {
                    compFlag = false;
                    Console.Write(customMessage);
                    Assert.Fail(customMessage);
                }
            }
            catch (Exception e)
            {
                string msg = ("Error occurred while doing the compareobject action " + "Exception :" + e);
                Console.Write(msg);
                Assert.Fail(msg);
            }
            return compFlag;
        }

        public bool ContainsText(String strActualText, String strCompText)
        {
            bool compFlag = false;
            try
            {
                if (strActualText.ToLower().Contains(strCompText.ToLower()))
                {
                    compFlag = true;
                }
                else
                {
                    compFlag = false;
                    Console.Write(strActualText + " doesnot match with " + strCompText);
                }
            }
            catch (Exception e)
            {
                string msg = ("Error occurred while doing the ContainsText action " + "Exception :" + e);
                Console.Write(msg);
                Assert.Fail(msg);
            }
            return compFlag;
        }

        #endregion

        #region Tab

        public void SelectTab(GuiTabStrip tab, int index)
        {
            if (tab == null)
            {
                throw new Exception("tab cannot be null");
            }

            if (index == 0)
            {
                throw new Exception("index cannot be null");
            }

            GuiComponentCollection collection = null;
            collection = tab.Children;

            if (collection.Length > 0)
            {
                for (int i = 0; i < tab.Children.Count; i++)
                {
                    GuiTab guiTab = tab.Children.ElementAt(i) as GuiTab;
                    if (i == index - 1)
                    {
                        guiTab.Select();
                        break;
                    }
                }
            }
            else
            {
                throw new Exception("No tab to select");
            }

        }

        public void SelectTab(GuiTabStrip tab, string title)
        {
            if (tab == null)
            {
                throw new Exception("tab cannot be null");
            }

            if (string.IsNullOrEmpty(title))
            {
                throw new Exception("title cannot be null");
            }

            GuiComponentCollection collection = null;
            collection = tab.Children;

            if (collection.Length > 0)
            {
                for (int i = 0; i < tab.Children.Count; i++)
                {
                    GuiTab guiTab = tab.Children.ElementAt(i) as GuiTab;
                    if (guiTab.Text.Trim().IndexOf(title, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        guiTab.Select();
                        break;
                    }
                }
            }
            else
            {
                throw new Exception("No tab to select");
            }
        }

        public string GetSelectedTab(GuiTabStrip tab)
        {
            if (tab == null)
            {
                throw new Exception("tab cannot be null");
            }

            string tabText = string.Empty;
            GuiComponentCollection collection = null;
            collection = tab.Children;

            if (collection.Length > 0)
            {
                for (int i = 0; i < tab.Children.Count; i++)
                {
                    GuiTab guiTab = tab.Children.ElementAt(i) as GuiTab;

                    if (guiTab.Changeable)
                    {
                        tabText = guiTab.Text;
                        break;
                    }
                }
            }
            else
            {
                throw new Exception("No tab to select");
            }
            return tabText;
        }


        #endregion

        #region GuiCTextField
        /// <summary>
        /// enter text on a GuiCTextField type control
        /// </summary>
        /// <param name="txt">GUITextField</param>
        /// <param name="value">text to enter</param>
        public void EnterTextInGuiCTextField(GuiCTextField txt, string value)
        {
            if (txt == null)
            {
                throw new Exception("txt cannot be null");
            }
            txt.SetFocus();
            txt.Text = value.Trim();
            txt.CaretPosition = value.Trim().Length;
        }
        /// <summary>
        /// get text on a GuiCTextField type control
        /// </summary>
        /// <param name="txt">GUITextField</param> 
        public string GetTextFromGuiCTextField(GuiCTextField txt)
        {
            if (txt == null)
            {
                throw new Exception("txt cannot be null");
            }
            txt.SetFocus();
            return txt.Text.Trim();
        }
        #endregion

        #region Menubar

        public void SelectMenuItem(GuiMenu mbar)
        {

            if (mbar == null)
            {
                throw new Exception("menu bar cannot be null");
            }
            mbar.Select();
        }

        public void SelectTabItem(GuiTab tbar)
        {

            if (tbar == null)
            {
                throw new Exception("tab cannot be null");
            }
            tbar.Select();
        }

        #endregion

    }
}
