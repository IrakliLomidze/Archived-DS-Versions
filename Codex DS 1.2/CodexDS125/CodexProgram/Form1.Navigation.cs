using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using ILG.Codex2007;
using ILG.Windows.Forms;
using ILG.Codex.WindowsForms;
using ILG.Codex2007.Strings;
using ILG.Codex.CodexListBox;

namespace ILG.Codex.Codex2007
{
    partial class Form1
    {
        #region NavigationDOC
        public class DocsNav
        {

            public struct DocsSt
            {
                public int index;
                public string tcaption;
                public string dcaption;
            }
            public ArrayList Docs;
            public int pos = 0;
            public bool backtolist = true;

            public DocsNav()
            {
                //
                // TODO: Add constructor logic here
                //
            }

            public void newdoc(int index, string tcaption, string dcaption)
            {
                Docs = new ArrayList();
                DocsSt itm = new DocsSt();
                itm.tcaption = tcaption;
                itm.index = index;
                itm.dcaption = dcaption;
                Docs.Add(itm);
                pos = 0;
            }

            public void adddoc(int index, string tcaption, string dcaption)
            {
                DocsSt itm = new DocsSt();
                itm.tcaption = tcaption;
                itm.dcaption = dcaption;
                itm.index = index;
                Docs.Add(itm);
                pos++;
            }

            public bool islast()
            {
                if (pos == Docs.Count - 1) return true; else return false;
            }

            public bool isfirst()
            {
                if (pos == 0) return true; else return false;
            }

            public bool back()
            {
                if (isfirst() || isnotcreated()) return false;
                else { pos--; return true; }

            }

            bool isnotcreated()
            {
                if (Docs == null) return true; else return false;
            }

            public bool forward()
            {
                if (islast() == false) { pos++; return true; }
                else return false;
            }

            static public void Generatedlast()
            {
            }

            static public void Generatedfirst()
            {
            }
        }

        #endregion NavigationDOC


        public int CodexPos;
        

        public bool CodexList;
        
        public DocsNav CodexDocsNav;
        
        public void NavigationInistialize()
        {
            //
            // TODO: Add constructor logic here
            //
            this.CodexList = false;
            
            this.CodexDocsNav = new DocsNav();

        }

        public void DoBack()
        {
           
            switch (ActiveProgram)
            {
                case 2:
                    {
                        
                       
                        if (CodexPos == 1) { CodexPos--; HomeClick(); return; }
                        if (CodexPos == 2)
                        {
                            if (CodexDocsNav.back() == false)
                            // Go to List
                            {
                                if ((CodexPos == 2) && (CodexDocsNav.backtolist == false)) { return; }
                                CodexPos--; CallList(); }
                            else
                            {
                                //  Go to Doc
                                DocsNav.DocsSt item;
                                item = (DocsNav.DocsSt)CodexDocsNav.Docs[CodexDocsNav.pos];
                                CodexListEventArgs e = new CodexListEventArgs(item.index, item.tcaption, item.dcaption);
                                codexListBox1_DocumentClick2(e, false);
                            }
                            return;
                        }
                    }
                    break;
            }

            return;
        }




        public void DoForward()
        {
            switch (ActiveProgram)
            {
            
                   
                
                    
                
            case 2:
                if ((CodexPos == 0) && (CodexList == false)) {return; }
                if (CodexPos == 0) { CodexPos++; CallList(); return; }

                #region navigateion in documents
                if (CodexPos == 2)
                {
                    if (CodexDocsNav.forward() == false)
                    // Go to List
                    {// Do Nothinh ;
                    }
                    else
                    {
                        //  Go to Doc
                        DocsNav.DocsSt item;
                        item = (DocsNav.DocsSt)CodexDocsNav.Docs[CodexDocsNav.pos];
                        //LocalVars.CodexDocsForm.calldoc(item.index, false);
                        CodexListEventArgs e = new CodexListEventArgs(item.index, item.tcaption, item.dcaption);
                        codexListBox1_DocumentClick2(e, false);

                    }

                    return;
                }
                #endregion navigateion in documents

                #region navigation from list to documents
                if (CodexPos == 1)
                {
                    if (CodexDocsNav.backtolist == false) return;
                    if (CodexDocsNav.Docs == null)
                    // Go to List
                    {// Do Nothinh ;
                    }
                    else
                    {
                        //  Go to Doc

                        DocsNav.DocsSt item;
                        item = (DocsNav.DocsSt)CodexDocsNav.Docs[CodexDocsNav.pos];

                        CodexListEventArgs e = new CodexListEventArgs(item.index, item.tcaption, item.dcaption);
                        codexListBox1_DocumentClick2(e, false);


                    }

                    return;
                }
               
                #endregion navigation from list to documents

                
                break;
            
            }

        }
    
        
        // ----------------------------------------------------------------------------------

        public void ShowInNewWindows(int AP,int DocumentID,string DocumentTCaption,string DocumentDCaption)
        {
            Form1 fnn = new Form1(true);
            fnn.ForceExit = true;
            //fnn.Show();
            //MessageBox.Show(AP.ToString());
            switch (AP)
            {
                case 2:
                    {
                        fnn.ActiveProgram = 2;
                        CodexListEventArgs er = new CodexListEventArgs(DocumentID, DocumentTCaption, DocumentDCaption);
                        fnn.CodexTab.SelectedTab = fnn.CodexTab.Tabs[2];
                        fnn.Show();
                        //fnn.MainTabs.SelectedTab = fnn.MainTabs.Tabs[2];
                        fnn.codexListBox1_DocumentClick3(null, er);
                        if (fnn.ForceExit == true) return;
                        fnn.CodexToolBar.Ribbon.SelectedTab = fnn.CodexToolBar.Ribbon.Tabs[0];
                        fnn.CodexTab.SelectedTab = fnn.CodexTab.Tabs[2];
                        fnn.CodexDocsNav.backtolist = false;
                        fnn.CaptionGeneration();
                    } break;
                
            }


            

        }
    
    
    }
}