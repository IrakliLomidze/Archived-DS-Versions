using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using ILG.Codex2007;
using ILG.Windows.Forms;
using ILG.Codex2007.Favorites;
using Infragistics.Win.UltraWinTree;
using Infragistics.Win.UltraWinToolTip;
using System.Drawing;
using Infragistics.Win;
using ILG.CodexR4.Favorites;
using ILG.Codex.CodexR4.UI;
using System.IO;

namespace ILG.Codex.CodexR4
{
    partial class Form1
    {
        private UltraTree_DropHightLight_DrawFilter_Class UltraTree_DropHightLight_DrawFilter = new UltraTree_DropHightLight_DrawFilter_Class();



        //The DragDrop event. Here we respond to a Drop on the tree
        private void UltraTree1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            //A dummy node variable used for various things
            UltraTreeNode aNode;
            //The SelectedNodes which will be dropped
            SelectedNodesCollection SelectedNodes;
            //The Node to Drop On
            Infragistics.Win.UltraWinTree.UltraTreeNode DropNode;
            //An integer used for loops
            int i;

            //Set the DropNode
            DropNode = UltraTree_DropHightLight_DrawFilter.DropHightLightNode;

            //Get the Data and put it into a SelectedNodes collection,
            //then clone it and work with the clone
            //These are the nodes that are being dragged and dropped
            SelectedNodes = (SelectedNodesCollection)e.Data.GetData(typeof(SelectedNodesCollection));
            SelectedNodes = SelectedNodes.Clone() as SelectedNodesCollection;

            //Sort the selected nodes into their visible position. 
            //This is done so that they stay in the same order when
            //they are repositioned. 
            SelectedNodes.SortByPosition();

            //Determine where we are dropping based on the current
            //DropLinePosition of the DrawFilter
            switch (UltraTree_DropHightLight_DrawFilter.DropLinePosition)
            {
                case DropLinePositionEnum.OnNode: //Drop ON the node
                    {
                        //Loop through the SelectedNodes and reposition
                        //them to the node that was dropped on.
                        //Note that the DrawFilter keeps track of what
                        //node the mouse is over, so we can just use
                        //DropHighLightNode as the drop target. 
                        for (i = 0; i <= (SelectedNodes.Count - 1); i++)
                        {
                            aNode = SelectedNodes[i];
                            aNode.Reposition(DropNode.Nodes);
                        }
                        break;
                    }
                case DropLinePositionEnum.BelowNode: //Drop Below the node
                    {
                        for (i = 0; i <= (SelectedNodes.Count - 1); i++)
                        {
                            aNode = SelectedNodes[i];
                            aNode.Reposition(DropNode, Infragistics.Win.UltraWinTree.NodePosition.Next);
                            //Change the DropNode to the node that was
                            //just repositioned so that the next 
                            //added node goes below it. 
                            DropNode = aNode;
                        }
                        break;
                    }
                case DropLinePositionEnum.AboveNode: //New Index should be the same as the Drop
                    {
                        for (i = 0; i <= (SelectedNodes.Count - 1); i++)
                        {
                            aNode = SelectedNodes[i];
                            aNode.Reposition(DropNode, Infragistics.Win.UltraWinTree.NodePosition.Previous);
                        }
                        break;
                    }
            }

            //After the drop is complete, erase the current drop
            //highlight. 
            UltraTree_DropHightLight_DrawFilter.ClearDropHighlight();
        }

        private void UltraTree1_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
        {
            //A dummy node variable used to hold nodes for various 
            //things
            UltraTreeNode aNode;
            //The Point that the mouse cursor is on, in Tree coords. 
            //This event passes X and Y in form coords. 
            System.Drawing.Point PointInTree;

            //Get the position of the mouse in the tree, as opposed
            //to form coords
            PointInTree = UltraTree1.PointToClient(new Point(e.X, e.Y));

            //Get the node the mouse is over.
            aNode = UltraTree1.GetNodeFromPoint(PointInTree);

            //Make sure the mouse is over a node
            if (aNode == null)
            {
                //The Mouse is not over a node
                //Do not allow dropping here
                e.Effect = DragDropEffects.None;
                //Erase any DropHighlight
                UltraTree_DropHightLight_DrawFilter.ClearDropHighlight();
                //Exit stage left
                return;
            }

            ///  IRAKLI		
            ///			//	Don't let Folder nodes be dropped onto other Folder nodes
            ///			if ( this.IsFolderNode(aNode) && this.IsFolderNodeSelected( this.UltraTree1 ) )
            ///			{
            ///				if ( PointInTree.Y > (aNode.Bounds.Top + 2) &&
            ///					 PointInTree.Y < (aNode.Bounds.Bottom - 2) )
            ///				{
            ///					e.Effect = DragDropEffects.None;
            ///					UltraTree_DropHightLight_DrawFilter.ClearDropHighlight();
            ///					return;
            ///				}
            ///			}

            //Check to see if we are dropping onto a node who//s
            //parent (grandparent, etc) is selected.
            //This is to prevent the user from dropping a node onto
            //one of it//s own descendents. 
            /// Irakli			if (IsAnyParentSelected(aNode))
            ///			{
            ///				//Mouse is over a node whose parent is selected
            ///				//Do not allow the drop
            ///				e.Effect = DragDropEffects.None;
            ///				//Clear the DropHighlight
            ///				UltraTree_DropHightLight_DrawFilter.ClearDropHighlight();
            ///				//Exit stage left
            ///				return;
            ///			}

            //If we//ve reached this point, it//s okay to drop on this node
            //Tell the DrawFilter where we are by calling SetDropHighlightNode
            UltraTree_DropHightLight_DrawFilter.SetDropHighlightNode(aNode, PointInTree);
            //Allow Dropping here. 
            e.Effect = DragDropEffects.Move;
        }

        //Proc to check whether a node is a Folder or not. 
        //This is necessary because we only want Folders to be 
        //parent nodes. We don't want countries to contain other
        //countries
        private bool IsFolderNode(UltraTreeNode Node)
        {
            //The Key of the node
            string NodeKey;
            //The beginning of the key
            string[] ParsedNodeKey;

            //Get the key of the node
            NodeKey = Node.Key;

            //Parse it out by colon
            ParsedNodeKey = NodeKey.Split(':');

            //If the beginning of the key says Folder, then 
            //we know it's a Folder node. 
            return (ParsedNodeKey[0] == "Folder");
        }

        /// <summary>
        /// Returns whether any of the currently selected nodes in the
        /// specified UltraTree control represent Folders.
        /// </summary>
        /// <param name="tree">The UltraTree control to evaluate.</param>
        /// <returns>A boolean indicating whether any Folder nodes are selected.</returns>
        private bool IsFolderNodeSelected(UltraTree tree)
        {
            foreach (UltraTreeNode selectedNode in tree.SelectedNodes)
            {
                if (this.IsFolderNode(selectedNode))
                    return true;
            }

            return false;
        }

        //Test to see if we want to continue dragging		
        private void UltraTree1_QueryContinueDrag(object sender, System.Windows.Forms.QueryContinueDragEventArgs e)
        {
            //Did the user press escape? 
            if (e.EscapePressed)
            {
                //User pressed escape
                //Cancel the Drag
                e.Action = DragAction.Cancel;
                //Clear the Drop highlight, since we are no longer
                //dragging
                UltraTree_DropHightLight_DrawFilter.ClearDropHighlight();
            }
        }


        //Occassionally, the DrawFilter will let us know that the 
        //control needs to be invalidated. 
        private void UltraTree_DropHightLight_DrawFilter_Invalidate(object sender, System.EventArgs e)
        {
            //Any time the drophighlight changes, the control needs 
            //to know that it has to repaint. 
            //It would be more efficient to only invalidate the area
            //that needs it, but this works and is very clean.
            UltraTree1.Invalidate();
        }

        //This event is fired by the DrawFilter to let us determine
        //what kinds of drops we want to allow on any particular node
        private void UltraTree_DropHightLight_DrawFilter_QueryStateAllowedForNode(Object sender, UltraTree_DropHightLight_DrawFilter_Class.QueryStateAllowedForNodeEventArgs e)
        {
            //	Don't let Folder nodes be dropped onto other Folder nodes
            if (this.IsFolderNode(e.Node) && this.IsFolderNodeSelected(this.UltraTree1))
            {
                e.StatesAllowed = DropLinePositionEnum.AboveNode | DropLinePositionEnum.BelowNode;
                return;
            }


            //Check to see if this is a Folder node. 
            if (!IsFolderNode(e.Node))
            {
                //This is not a Folder
                //Allow users to drop above or below this node - but not on
                //it, because countries don//t have child countries
                e.StatesAllowed = DropLinePositionEnum.AboveNode | DropLinePositionEnum.BelowNode;

                //Since we can only drop above or below this node, 
                //we don//t want a middle section. So we set the 
                //sensitivity to half the height of the node
                //This means the DrawFilter will respond to the top half
                //bottom half of the node, but not the middle. 
                UltraTree_DropHightLight_DrawFilter.EdgeSensitivity = e.Node.Bounds.Height / 2;
            }
            else
            {
                if (e.Node.Selected)
                {
                    //This is a selected Folder node. 
                    //Since it is selected, we don't want to allow
                    //dropping ON this node. But we can allow the
                    //the user to drop above or below it. 
                    e.StatesAllowed = DropLinePositionEnum.AboveNode | DropLinePositionEnum.BelowNode;
                    UltraTree_DropHightLight_DrawFilter.EdgeSensitivity = e.Node.Bounds.Height / 2;
                }
                else
                {
                    //This is a Folder node and is not selected
                    //We can allow dropping here above, below, or on this
                    //node. Since the StatesAllow defaults to All, we don't 
                    //need to change it. 
                    //We set the EdgeSensitivity to 1/3 so that the 
                    //Drawfilter will respond at the top, bottom, or 
                    //middle of the node. 
                    UltraTree_DropHightLight_DrawFilter.EdgeSensitivity = e.Node.Bounds.Height / 3;
                }
            }
        }

        //Walks up the parent chain for a node to determine if any
        //of it's parent nodes are selected
        private bool IsAnyParentSelected(UltraTreeNode Node)
        {
            UltraTreeNode ParentNode;
            bool ReturnValue = false;

            ParentNode = Node.Parent;
            while (ParentNode != null)
            {
                if (ParentNode.Selected)
                {
                    ReturnValue = true;
                    break;
                }
                else
                {
                    ParentNode = ParentNode.Parent;
                }
            }

            return ReturnValue;
        }

        //Fires when the user drags outside the control. 
        private void UltraTree1_DragLeave(object sender, System.EventArgs e)
        {
            //When the mouse goes outside the control, clear the 
            //drophighlight. 
            //Since the DropHighlight is cleared when the 
            //mouse is not over a node, anyway, 
            //this is probably not needed
            //But, just in case the user goes from a node directly
            //off the control...
            UltraTree_DropHightLight_DrawFilter.ClearDropHighlight();
        }

        private void UltraTree1_SelectionDragStart(object sender, System.EventArgs e)
        {
            //Start a DragDrop operation
            UltraTree1.DoDragDrop(UltraTree1.SelectedNodes, DragDropEffects.Move);
        }

        //Test to see if we want to continue dragging	

        private void LoadTree()
        {

           // UltraTreeNode FolderNode;
           // UltraTreeNode DocumentNode;


            UltraTree1.Appearances.Add("DropHighLightAppearance");
            UltraTree1.Appearances["DropHighLightAppearance"].BackColor = Color.Cyan;



            //UltraTree1.ImageList = ImageList1; // ZXZ Trr
            return;
            

        }

        private void UltraTree1_MouseEnterElement(object sender, Infragistics.Win.UIElementEventArgs e)
        {
            TreeNodeUIElement nodeElement = e.Element as TreeNodeUIElement;

            if (nodeElement != null)
            {
                //HotNodeIndex = nodeElement.Node.Index;

                UltraTreeNode node = nodeElement.Node;

                UltraTree1.ActiveNode = node;
                string T1 = node.Text;
                if (node.Tag != null)
                {
                    T1 = node.Tag.ToString();
                    if (T1.Length >= "Document:".Length) T1 = T1.Substring("Document:".Length,T1.Length-"Document:".Length);
                }

                UltraToolTipInfo toolTipInfo = new UltraToolTipInfo(T1 , ToolTipImage.Info, node.Text, DefaultableBoolean.True);

                //this.ultraToolTipManager1.ToolTipTitle = node.Text;

                this.ultraToolTipManager1.SetUltraToolTip(this.UltraTree1, toolTipInfo);//, node.Text + "'s TsdaldhfklshflkshdflkhasdflhsadfhalsfhlashflkajhsfoolTip");
                //this.toolTip1.SetToolTip(this.UltraTree1, node.Text + "'s TsdaldhfklshflkshdflkhasdflhsadfhalsfhlashflkajhsfoolTip");
                //this.toolTip1.Active = true;
                this.ultraToolTipManager1.ShowToolTip(this.UltraTree1);

                PopUpMenuDesigner();

            }
        }

        private void UltraTree1_MouseLeaveElement(object sender, Infragistics.Win.UIElementEventArgs e)
        {
            PopUpMenuDesigner();
            //this.ultraToolTipManager1.ShowToolTip(null);
        }
        // =========================================================================
        // Actions

        private void RenameItem()
        {
            /*if ((UltraTree1.ActiveNode.Key == "Folder:Codex") || (UltraTree1.ActiveNode.Key == "Folder:CGL") ||
            (UltraTree1.ActiveNode.Key == "Folder:ICG"))
            {
                ILG.Windows.Forms.ILGMessageBox.Show("არ შეიძლება ძირითადი ფოლდერების შეცვლა");
                return;
            }*/
            UltraTree1.ActiveNode.BeginEdit();
        }

        private void DeleteItem()
        {

            /*if ((UltraTree1.ActiveNode.Key == "Folder:Codex") || (UltraTree1.ActiveNode.Key == "Folder:CGL") ||
         (UltraTree1.ActiveNode.Key == "Folder:ICG"))
            {
                ILG.Windows.Forms.ILGMessageBox.Show("არ შეიძლება ძირითადი ფოლდერების  წაშლა");
                return;
            }*/
            if (ILG.Windows.Forms.ILGMessageBox.Show("გსურთ ელემენტი \n" + UltraTree1.ActiveNode.Text + "\n ფავორიტების სიიდან ამოღება ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                UltraTree1.ActiveNode.Remove();
        }

        private void NewFolder()
        {
            String U1 = DateTime.Now.Ticks.ToString();
            while (UltraTree1.Nodes.Exists("Folder:" + U1) == true)
                U1 = DateTime.Now.Ticks.ToString();
            UltraTreeNode FolderNode;
            FolderNode = UltraTree1.Nodes.Add("Folder:" + U1, "ახალი ფოლდერი");
            FolderNode.Override.NodeAppearance.Image = 0;
            FolderNode.Override.HotTracking = Infragistics.Win.DefaultableBoolean.True;
        }

        private void ExpandItem()
        {
            UltraTree1.ActiveNode.Expanded = true;
        }

        private void ColapseItem()
        {

            UltraTree1.ActiveNode.Expanded = false;
        }

        private void PopUpMenuDesigner()
        {
            if (UltraTree1.ActiveNode == null) return;


            if (UltraTree1.ActiveNode.Key.Length < 7)
            {
                DefaultPopUp();
                return;
            }


            if (UltraTree1.ActiveNode.Key.Length >= 7)
            {
                if (UltraTree1.ActiveNode.Key.Substring(0, 7) == "Folder:")
                {
                    #region Expand & Colapse
                    if (UltraTree1.ActiveNode.Expanded == true)
                    {
                        CodexToolBar.Tools["Favorites_Expand"].SharedProps.Visible = false;
                        CodexToolBar.Tools["Favorites_Expand"].SharedProps.Enabled = false;

                        CodexToolBar.Tools["Favorites_Colaspe"].SharedProps.Visible = true;
                        CodexToolBar.Tools["Favorites_Colaspe"].SharedProps.Enabled = true;

                    }
                    else
                    {
                        CodexToolBar.Tools["Favorites_Expand"].SharedProps.Visible = true;
                        CodexToolBar.Tools["Favorites_Expand"].SharedProps.Enabled = true;

                        CodexToolBar.Tools["Favorites_Colaspe"].SharedProps.Visible = false;
                        CodexToolBar.Tools["Favorites_Colaspe"].SharedProps.Enabled = false;
                    }



                    if (UltraTree1.ActiveNode.HasNodes == true)
                    {
                        CodexToolBar.Tools["Favorites_Expand"].SharedProps.Visible = true;
                        CodexToolBar.Tools["Favorites_Expand"].SharedProps.Enabled = true;


                    }

                    #endregion Expand & Colapse

                        PopUponFolder();

                }
            }



            if (UltraTree1.ActiveNode.Key.Substring(0, 9) == "Document:")
            {
                PopUponElement();
            }



        }

        void DefaultPopUp()
        {
            CodexToolBar.Tools["History_Clear"].SharedProps.Visible = false;
            CodexToolBar.Tools["History_Clear"].SharedProps.Enabled = false;

            CodexToolBar.Tools["Favorites_Clear"].SharedProps.Visible = true;
            CodexToolBar.Tools["Favorites_Clear"].SharedProps.Enabled = true;
            
            
            CodexToolBar.Tools["Favorites_Rename"].SharedProps.Visible = false;
            CodexToolBar.Tools["Favorites_Rename"].SharedProps.Enabled = false;
            CodexToolBar.Tools["Favorites_Remove"].SharedProps.Visible = false;
            CodexToolBar.Tools["Favorites_Remove"].SharedProps.Enabled = false;
            CodexToolBar.Tools["Favorites_OpenNew"].SharedProps.Visible = false;
            CodexToolBar.Tools["Favorites_OpenNew"].SharedProps.Enabled = false;
            CodexToolBar.Tools["Favorites_Open"].SharedProps.Visible = false;
            CodexToolBar.Tools["Favorites_Open"].SharedProps.Enabled = false;
            CodexToolBar.Tools["Favorites_Expand"].SharedProps.Visible = false;
            CodexToolBar.Tools["Favorites_Expand"].SharedProps.Enabled = false;

            CodexToolBar.Tools["Favorites_Colaspe"].SharedProps.Visible = false;
            CodexToolBar.Tools["Favorites_Colaspe"].SharedProps.Enabled = false;


        }

        void PopUponFolder()
        {
            CodexToolBar.Tools["History_Clear"].SharedProps.Visible = false;
            CodexToolBar.Tools["History_Clear"].SharedProps.Enabled = false;

            CodexToolBar.Tools["Favorites_Clear"].SharedProps.Visible = true;
            CodexToolBar.Tools["Favorites_Clear"].SharedProps.Enabled = true;
            
            CodexToolBar.Tools["Favorites_Rename"].SharedProps.Visible = true;
            CodexToolBar.Tools["Favorites_Rename"].SharedProps.Enabled = true;
            CodexToolBar.Tools["Favorites_Remove"].SharedProps.Visible = true;
            CodexToolBar.Tools["Favorites_Remove"].SharedProps.Enabled = true;
            CodexToolBar.Tools["Favorites_OpenNew"].SharedProps.Visible = false;
            CodexToolBar.Tools["Favorites_OpenNew"].SharedProps.Enabled = false;
            CodexToolBar.Tools["Favorites_Open"].SharedProps.Visible = false;
            CodexToolBar.Tools["Favorites_Open"].SharedProps.Enabled = false;
        }


        void PopUponElement()
        {

            CodexToolBar.Tools["History_Clear"].SharedProps.Visible = false;
            CodexToolBar.Tools["History_Clear"].SharedProps.Enabled = false;

            CodexToolBar.Tools["Favorites_Clear"].SharedProps.Visible = true;
            CodexToolBar.Tools["Favorites_Clear"].SharedProps.Enabled = true;
            
            CodexToolBar.Tools["Favorites_OpenNew"].SharedProps.Visible = true;
            CodexToolBar.Tools["Favorites_OpenNew"].SharedProps.Enabled = true;
            CodexToolBar.Tools["Favorites_Open"].SharedProps.Visible = true;
            CodexToolBar.Tools["Favorites_Open"].SharedProps.Enabled = true;


            CodexToolBar.Tools["Favorites_Rename"].SharedProps.Visible = true;
            CodexToolBar.Tools["Favorites_Rename"].SharedProps.Enabled = true;
            CodexToolBar.Tools["Favorites_Remove"].SharedProps.Visible = true;
            CodexToolBar.Tools["Favorites_Remove"].SharedProps.Enabled = true;

            CodexToolBar.Tools["Favorites_Expand"].SharedProps.Visible = false;
            CodexToolBar.Tools["Favorites_Expand"].SharedProps.Enabled = false;

            CodexToolBar.Tools["Favorites_Colaspe"].SharedProps.Visible = false;
            CodexToolBar.Tools["Favorites_Colaspe"].SharedProps.Enabled = false;

        }

        private void LoadTreeData()
        {
            using (new WaitCursor())
            {
                string FavoritesFile = "CodexDS16.Favorites.XML";  //FavoritesFile = "Codex2007DS.Favorites.XML";

                string FavoritesFileNameFull = DirectoryConfiguration.FavoriteDocumentsDirectory + "\\" + FavoritesFile;
                if (File.Exists(FavoritesFileNameFull) == true)
                {
                    try
                    {
                        UltraTree1.LoadFromXml(FavoritesFileNameFull);
                    }
                    catch (Exception ex)
                    {
                        ILGMessageBox.ShowE("არ ხერხდება ფავორიტების სიის წაკითხვა", ex.Message);
                        string FavoritesFileBackp = $"CodexDS16.Favorites.XML.{DateTime.Now.Ticks.ToString()}.Backup";
                        File.Copy(FavoritesFileNameFull, FavoritesFileBackp, true);
                        UltraTree1.Nodes.Clear();
                    }
                }
                else
                {
                    UltraTree1.Nodes.Clear();
                }
            }
                

        }

        private void SaveTreeData()
        {

            using (new WaitCursor())
            {
                string _filename = "CodexDS16.Favorites.XML";

                if (Directory.Exists(DirectoryConfiguration.FavoriteDocumentsDirectory) == false)
                    Directory.CreateDirectory(DirectoryConfiguration.FavoriteDocumentsDirectory);

                string s1 = Path.Combine(DirectoryConfiguration.FavoriteDocumentsDirectory, _filename);

                string temp = DateTime.Now.Ticks.ToString() + "_tempF.xml";
                string TempFile = Path.Combine(DirectoryConfiguration.FavoriteDocumentsDirectory, temp);

                try
                {
                    if (File.Exists(s1) == true) 
                    File.Copy(s1, TempFile);
                }
                catch (Exception ex)
                {
                    ILGMessageBox.ShowE("არ ხერხდება ფავორიტების სიის ჩაწერა (#1) ", ex.Message);

                    return;
                }
                try
                {
                    UltraTree1.SaveAsXml(s1);
                    CodexFile.DeleteIfExists(TempFile);

                }
                catch (Exception ex)
                {
                    ILGMessageBox.ShowE("არ ხერხდება ფავორიტების სიის ჩაწერა (#2)", ex.Message);
                    File.Copy(TempFile, s1);
                    CodexFile.DeleteIfExists(TempFile);

                }
            }
            
        }

        private void AddtoFavorites(int ID, string tcaption, string dcaption)
        {
            FavoritesWindows fv = new FavoritesWindows();
            fv.ultraTextEditor1.Text = tcaption;
            fv.ultraTextEditor2.Text = dcaption;
            string ss = "";
             ss = "Codex"; 
    


            if (fv.ShowDialog() == DialogResult.OK)
            { 
                String U1 = DateTime.Now.Ticks.ToString();
                while (UltraTree1.Nodes.Exists("Document:" + ss + ";" + ID.ToString() + "_" + U1) == true)
                    U1 = DateTime.Now.Ticks.ToString();
                UltraTreeNode DocumentNode;
                DocumentNode = UltraTree1.Nodes.Add("Document:" + ss + ";" + ID.ToString() + "_" + U1, fv.ultraTextEditor1.Text /* tcaption */);
                DocumentNode.Tag = "Document:"+dcaption;
                DocumentNode.Override.NodeAppearance.Image = 1;
                DocumentNode.Override.HotTracking = Infragistics.Win.DefaultableBoolean.True;
                DocumentNode.Override.TipStyleNode = TipStyleNode.Hide;
                if (ForceExit == false) SaveTreeData();
            }


        }

        private void CallFavoriteList()
        {

            #region Tree
            //Attach the Drawfiler to the tree
            UltraTree1.DrawFilter = UltraTree_DropHightLight_DrawFilter;
            ///DefaultPopUp();
            //Populate the Tree with Data
            //this.UltraTree1.Nodes.AllowDuplicateKeys = true;
            //  LoadTree();

            DefaultPopUp();

            UltraTree1.Override.SelectionType = Infragistics.Win.UltraWinTree.SelectType.ExtendedAutoDrag;
            //LoadTree();
            LoadTreeData();

            //UltraTree1.LoadFromXml("C:\\1.xml");
            #endregion Tree

            this.FavoriteTab.Show();

            this.ultraDockManager1.ControlPanes[0].Closed = false;
            this.ultraDockManager1.ControlPanes[0].Text = "ფავორიტები";
            this.ultraDockManager1.ControlPanes[0].Activate();
        }
        

        private void UltraTree1_DoubleClick(object sender, EventArgs e)
        {
            ClickFavorites();
        }

        private void UltraTree1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void ClickFavorites()
        {

            string s = UltraTree1.ActiveNode.Key;
            if (s.Length > 7)
            {
                if (s.Substring(0, 7) == "Folder:") return;

            }
            if (s.Length > 9)
            {
                int i = s.IndexOf(";");
                int j = s.IndexOf("_");
                //MessageBox.Show(s.Substring(i + 1, j - i - 1));

                int ID_FAV = -1;
                if (Int32.TryParse(s.Substring(i + 1, j - i - 1),out ID_FAV) == false)
                {
                    ILG.Windows.Forms.ILGMessageBox.Show("ბაზაში არ მოიძებნა ფავორიტების შესაბამისი დოკუმენტი");
                    return;
                }

                ShowInNewWindows(2, ID_FAV, "", ""); 
                
            }



        }

        // Tab Button Cklicked
        private void ultraButton6_Click(object sender, EventArgs e)
        {
            // Load Favorites
            CallFavoriteList();
        }


        private void ClearFavorites()
        {
            if (ILG.Windows.Forms.ILGMessageBox.Show("ფავორიტების წაშლა ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            if (ILG.Windows.Forms.ILGMessageBox.Show("ფავორიტების წაშლა ? დაადასტურეთ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            this.UltraTree1.Nodes.Clear();
            if (ForceExit == false) SaveTreeData();
        }

  // History
//===================================================================================================================
        private void AddtoHistory(int ID, string tcaption, string dcaption)
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            string ss = "";
            { ss = "Codex"; }
   


                String U1 = DateTime.Now.Ticks.ToString();
                while (UltraTree1.Nodes.Exists("Document:" + ss + ";" + ID.ToString() + "_" + U1) == true)
                    U1 = DateTime.Now.Ticks.ToString();
                UltraTreeNode DocumentNode;
                DocumentNode = UltraTree2.Nodes.Insert(0,"Document:" + ss + ";" + ID.ToString() + "_" + U1, tcaption);
                DocumentNode.Tag = "Document:" + dcaption;
                DocumentNode.Override.NodeAppearance.Image = 1;
                DocumentNode.Override.HotTracking = Infragistics.Win.DefaultableBoolean.True;
                DocumentNode.Override.TipStyleNode = TipStyleNode.Hide;
            
            this.Cursor = System.Windows.Forms.Cursors.Default;
            SaveHistoryData();

        }

        private void SaveHistoryData()
        {
            using (new WaitCursor())
            {
                string _filename = "CodexDS16.History.xml"; 
                
                if (Directory.Exists(DirectoryConfiguration.FavoriteDocumentsDirectory) == false)
                    Directory.CreateDirectory(DirectoryConfiguration.FavoriteDocumentsDirectory);
                string HistoryFile = Path.Combine(DirectoryConfiguration.FavoriteDocumentsDirectory , _filename);
                string temp = DateTime.Now.Ticks.ToString() + "_temp.xml";
                string TempFile = Path.Combine(DirectoryConfiguration.FavoriteDocumentsDirectory, temp);

                try
                {
                    if (File.Exists(HistoryFile) == true)

                        File.Copy(HistoryFile, TempFile);
                }
                catch (Exception ex)
                {
                    ILGMessageBox.ShowE("არ ხერხდება ნავიგაციის ისტორიის სიის ჩაწერა (#1) ", ex.Message);

                    return;
                }

                try
                {
                    UltraTree2.SaveAsXml(HistoryFile);
                    CodexFile.DeleteIfExists(TempFile);
                }
                catch (Exception ex)
                {
                    ILGMessageBox.ShowE("არ ხერხდება ნავიგაციის ისტორიის სიის ჩაწერა (#2) ", ex.Message);
                    File.Copy(TempFile, HistoryFile);
                    CodexFile.DeleteIfExists(TempFile);
                }
            }
                

        }


        void HistoryPopUp()
        {
            CodexToolBar.Tools["History_Clear"].SharedProps.Visible = true;
            CodexToolBar.Tools["History_Clear"].SharedProps.Enabled = true;

            CodexToolBar.Tools["Favorites_Clear"].SharedProps.Visible = false;
            CodexToolBar.Tools["Favorites_Clear"].SharedProps.Enabled = false;
            
            
            CodexToolBar.Tools["Favorites_NewFolder"].SharedProps.Visible = false;
            CodexToolBar.Tools["Favorites_NewFolder"].SharedProps.Enabled = false;
            

            CodexToolBar.Tools["Favorites_Rename"].SharedProps.Visible = false;
            CodexToolBar.Tools["Favorites_Rename"].SharedProps.Enabled = false;
            CodexToolBar.Tools["Favorites_Remove"].SharedProps.Visible = false;
            CodexToolBar.Tools["Favorites_Remove"].SharedProps.Enabled = false;
            CodexToolBar.Tools["Favorites_OpenNew"].SharedProps.Visible = true;
            CodexToolBar.Tools["Favorites_OpenNew"].SharedProps.Enabled = true;
            CodexToolBar.Tools["Favorites_Open"].SharedProps.Visible = true;
            CodexToolBar.Tools["Favorites_Open"].SharedProps.Enabled = true;
            CodexToolBar.Tools["Favorites_Expand"].SharedProps.Visible = false;
            CodexToolBar.Tools["Favorites_Expand"].SharedProps.Enabled = false;
            CodexToolBar.Tools["Favorites_Colaspe"].SharedProps.Visible = false;
            CodexToolBar.Tools["Favorites_Colaspe"].SharedProps.Enabled = false;


        }


       private void LoadHistoryData()
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            string FavoritesFile = "";
            { FavoritesFile = "CodexDS16.History.xml"; }
       

            string s1 = DirectoryConfiguration.FavoriteDocumentsDirectory + "\\" + FavoritesFile;
            if (File.Exists(s1) == true)
            {
                try
                {
                    UltraTree2.LoadFromXml(s1);
                }
                catch (Exception ex)
                {
                    ILGMessageBox.ShowE("არ ხერხდება ნავიგაციის ისტორიის სიის წაკითხვა", ex.Message);
                    string HistoryFileBackp = $"CodexDS16.History.XML.{DateTime.Now.Ticks.ToString()}.Backup";
                    File.Copy(s1, HistoryFileBackp, true);

                    UltraTree2.Nodes.Clear();
                }
            }
            else
            {
                UltraTree2.Nodes.Clear();
            }

            this.Cursor = System.Windows.Forms.Cursors.Default;
        }
       


        private void CallHistoryList()
        {

            #region Tree
            //Attach the Drawfiler to the tree
            UltraTree2.DrawFilter = UltraTree_DropHightLight_DrawFilter;
            ///DefaultPopUp();
            //Populate the Tree with Data
            //this.UltraTree1.Nodes.AllowDuplicateKeys = true;
            //  LoadTree();

            HistoryPopUp();

            UltraTree2.Override.SelectionType = Infragistics.Win.UltraWinTree.SelectType.ExtendedAutoDrag;
            //LoadTree();
            LoadHistoryData();

            //UltraTree1.LoadFromXml("C:\\1.xml");
            #endregion Tree

            this.FavoriteTab.Show();

            this.ultraDockManager1.ControlPanes[0].Closed = false;
            this.ultraDockManager1.ControlPanes[0].Text = "ისტორია";
            this.ultraDockManager1.ControlPanes[0].Activate();
        }


        private void ultraButton5_Click(object sender, EventArgs e)
        {
            CallHistoryList();
            FavoriteTab.SelectedTab = FavoriteTab.Tabs[1];
        }

        private void ultraButton16_Click(object sender, EventArgs e)
        {
            CallFavoriteList();
            FavoriteTab.SelectedTab = FavoriteTab.Tabs[0];
        }

        private void ClickHistory()
        {

            string s = UltraTree2.ActiveNode.Key;
            if (s.Length > 7)
            {
                if (s.Substring(0, 7) == "Folder:") return;

            }
            if (s.Length > 9)
            {
                int i = s.IndexOf(";");
                int j = s.IndexOf("_");
                //MessageBox.Show(s.Substring(i + 1, j - i - 1));
                int ID_FAV = -1;
                if (Int32.TryParse(s.Substring(i + 1, j - i - 1), out ID_FAV) == false)
                {
                    ILG.Windows.Forms.ILGMessageBox.Show("ბაზაში არ მოიძებნა ისტორიის შესაბამისი დოკუმენტი");
                    return;
                }
                 ShowInNewWindows(2, ID_FAV, "", ""); 
            
            }
        }


        private void UltraTree2_DoubleClick(object sender, EventArgs e)
        {
            ClickHistory();
        }


        private void UltraTree2_MouseEnterElement(object sender, Infragistics.Win.UIElementEventArgs e)
        {
            TreeNodeUIElement nodeElement = e.Element as TreeNodeUIElement;

            if (nodeElement != null)
            {
                //HotNodeIndex = nodeElement.Node.Index;

                UltraTreeNode node = nodeElement.Node;

                UltraTree2.ActiveNode = node;
                string T1 = node.Text;
                if (node.Tag != null)
                {
                    T1 = node.Tag.ToString();
                    if (T1.Length >= "Document:".Length) T1 = T1.Substring("Document:".Length, T1.Length - "Document:".Length);
                }

                UltraToolTipInfo toolTipInfo = new UltraToolTipInfo(T1, ToolTipImage.Info, node.Text, DefaultableBoolean.True);

                //this.ultraToolTipManager1.ToolTipTitle = node.Text;

                this.ultraToolTipManager1.SetUltraToolTip(this.UltraTree2, toolTipInfo);//, node.Text + "'s TsdaldhfklshflkshdflkhasdflhsadfhalsfhlashflkajhsfoolTip");
                //this.toolTip1.SetToolTip(this.UltraTree1, node.Text + "'s TsdaldhfklshflkshdflkhasdflhsadfhalsfhlashflkajhsfoolTip");
                //this.toolTip1.Active = true;
                this.ultraToolTipManager1.ShowToolTip(this.UltraTree2);

                HistoryPopUp();
                

            }
        }


        private void UltraTree2_MouseLeaveElement(object sender, Infragistics.Win.UIElementEventArgs e)
        {

        }


        private void ClearHistory()
        {
            if (ILG.Windows.Forms.ILGMessageBox.Show("ისტორიის წაშლა ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            if (ILG.Windows.Forms.ILGMessageBox.Show("ისტორიის წაშლა ? დაადასტურეთ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            this.UltraTree2.Nodes.Clear();
            SaveHistoryData();
        }

    }
}
