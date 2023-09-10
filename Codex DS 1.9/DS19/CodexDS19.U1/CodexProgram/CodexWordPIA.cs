using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;

namespace ILG.Codex.CodexR4
{
    class CodexWordPIA
    {

        // For "true", you need to use -1
        // For "false", you need to use 0
  
        public static int GenerateOpenDocument_V2(String BaseDocumentFileName, String DestinationDocumentFileName, String DocumentCaption, String DocumentDate, String HistoryDate)
        {

            const int WordTrue = -1;
            const int WordFalse = 0;

            if (File.Exists(BaseDocumentFileName) == false) return 1001;
            if (File.Exists(DestinationDocumentFileName) == true) return 1007;


            var word = new Microsoft.Office.Interop.Word.Application();

            try
            {
                word = new Microsoft.Office.Interop.Word.Application();
            }
            catch
            {
                return 1000;
            }
            

            word.Visible = false;
            word.ScreenUpdating = false;

            if ( (word.Version == "11.0") || (word.Version == "10.0") || (word.Version == "9.0") || (word.Version == "8.0") || (word.Version == "7.0") || (word.Version == "6.0"))
            {
                // if Word is Lower thatn 2007
                word.Quit();
                return 5000;
            }


            var doc_sBaseDocument = word.Documents.Open(FileName: BaseDocumentFileName, ConfirmConversions: false, ReadOnly: true);
            doc_sBaseDocument.ActiveWindow.View.ReadingLayout = false;
            // Delete All Headers and Footers From Document   

            foreach(Section wordSection in doc_sBaseDocument.Sections)
            {
                wordSection.Headers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.Delete();
                wordSection.Footers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.Delete();

                if (wordSection.PageSetup.OddAndEvenPagesHeaderFooter == 1)
                 {
                    wordSection.Headers[WdHeaderFooterIndex.wdHeaderFooterEvenPages].Range.Delete();
                    wordSection.Footers[WdHeaderFooterIndex.wdHeaderFooterEvenPages].Range.Delete();
                 }

                if (wordSection.PageSetup.DifferentFirstPageHeaderFooter == 1)
                 {
                    wordSection.Headers[WdHeaderFooterIndex.wdHeaderFooterFirstPage].Range.Delete();
                    wordSection.Footers[WdHeaderFooterIndex.wdHeaderFooterFirstPage].Range.Delete();
                }
            }
            
            doc_sBaseDocument.Activate();

            var HeaderRange = doc_sBaseDocument.Sections[1].Headers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
            var Table1 = HeaderRange.Tables.Add(HeaderRange, 1, 2);
            Table1.Cell(1, 1).Range.Text = "Codex DS";

            var CellRange = Table1.Cell(1, 2).Range;

            CellRange.Collapse(WdCollapseDirection.wdCollapseStart);

            var Filed2 = doc_sBaseDocument.Fields.Add(CellRange, WdFieldType.wdFieldNumPages);
            CellRange.InsertBefore(" of ");
            CellRange.Collapse(WdCollapseDirection.wdCollapseStart);

            var Filed1 = doc_sBaseDocument.Fields.Add(CellRange, WdFieldType.wdFieldPage);

            CellRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
            CellRange.LanguageID = WdLanguageID.wdNoProofing;


            Table1.Borders[WdBorderType.wdBorderBottom].LineStyle = WdLineStyle.wdLineStyleSingle;                              
            Table1.Borders[WdBorderType.wdBorderDiagonalDown].LineStyle = WdLineStyle.wdLineStyleNone;                          
            Table1.Borders[WdBorderType.wdBorderDiagonalUp].LineStyle = WdLineStyle.wdLineStyleNone;                            
            Table1.Borders[WdBorderType.wdBorderHorizontal].LineStyle = WdLineStyle.wdLineStyleNone;
            Table1.Borders[WdBorderType.wdBorderLeft].LineStyle = WdLineStyle.wdLineStyleNone;                                  
            Table1.Borders[WdBorderType.wdBorderRight].LineStyle = WdLineStyle.wdLineStyleNone;                                
            Table1.Borders[WdBorderType.wdBorderTop].LineStyle = WdLineStyle.wdLineStyleNone;                                  
            Table1.Borders[WdBorderType.wdBorderVertical].LineStyle = WdLineStyle.wdLineStyleNone;
            Table1.Borders[WdBorderType.wdBorderBottom].LineWidth = WdLineWidth.wdLineWidth025pt;


            var FooterRange = doc_sBaseDocument.Sections[1].Footers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
            var Table2 = HeaderRange.Tables.Add(FooterRange, 2, 2);

            var Footer_Cell_Left_Range = Table2.Cell(1, 1).Range;
            Footer_Cell_Left_Range.Text = DocumentCaption;
            Footer_Cell_Left_Range.Font.Name = "Sylfaen";
            Footer_Cell_Left_Range.Font.Size = 8.0f;
            Footer_Cell_Left_Range.Font.Bold = WordFalse;
            Footer_Cell_Left_Range.Font.Italic = WordFalse;
            Footer_Cell_Left_Range.LanguageID = WdLanguageID.wdNoProofing;

            var Footer_Cell_Right_Range = Table2.Cell(1, 2).Range;
            Footer_Cell_Right_Range.Text = DocumentDate;                                               
            Footer_Cell_Right_Range.Font.Name = "Sylfaen";                                             
            Footer_Cell_Right_Range.Font.Size = 8.0f;                                                   
            Footer_Cell_Right_Range.Font.Bold =  WordFalse;                                                 
            Footer_Cell_Right_Range.Font.Italic = WordFalse;
            Footer_Cell_Right_Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
            Footer_Cell_Right_Range.LanguageID = WdLanguageID.wdNoProofing;

            var Footer_Cell_Right_Range2 = Table2.Cell(2, 2).Range;                                    
            Footer_Cell_Right_Range2.Text = HistoryDate;                                              
            Footer_Cell_Right_Range2.Font.Name = "Sylfaen";
            Footer_Cell_Right_Range2.Font.Size = 8.0f;
            Footer_Cell_Right_Range2.Font.Bold = WordFalse;
            Footer_Cell_Right_Range2.Font.Italic = WordFalse;                                              
            Footer_Cell_Right_Range2.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
            Footer_Cell_Right_Range2.LanguageID = WdLanguageID.wdNoProofing;


            Table2.Cell(1, 1).Range.ParagraphFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;
            Table2.Cell(1, 2).Range.ParagraphFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;
            Table2.Cell(2, 1).Range.ParagraphFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;
            Table2.Cell(2, 2).Range.ParagraphFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;

            Table2.Cell(1, 1).Range.ParagraphFormat.SpaceAfter = 0;                                     
            Table2.Cell(1, 1).Range.ParagraphFormat.SpaceBefore = 0;                                    

            Table2.Cell(1, 2).Range.ParagraphFormat.SpaceAfter = 0;
            Table2.Cell(1, 2).Range.ParagraphFormat.SpaceBefore = 0;                                    

            Table2.Cell(2, 1).Range.ParagraphFormat.SpaceAfter = 0;                                     
            Table2.Cell(2, 1).Range.ParagraphFormat.SpaceBefore = 0;                                    

            Table2.Cell(2, 2).Range.ParagraphFormat.SpaceAfter = 0;                                     
            Table2.Cell(2, 2).Range.ParagraphFormat.SpaceBefore = 0;                                    

            Table1.Cell(1, 1).Range.ParagraphFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;                
            Table1.Cell(1, 2).Range.ParagraphFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;                

            Table1.Cell(1, 1).Range.ParagraphFormat.SpaceAfter = 0;                                     
            Table1.Cell(1, 1).Range.ParagraphFormat.SpaceBefore = 0;                                    

            Table1.Cell(1, 2).Range.ParagraphFormat.SpaceAfter = 0;                                     
            Table1.Cell(1, 2).Range.ParagraphFormat.SpaceBefore = 0;

            Table2.Borders[WdBorderType.wdBorderBottom].LineStyle = WdLineStyle.wdLineStyleNone;                                
            Table2.Borders[WdBorderType.wdBorderDiagonalDown].LineStyle = WdLineStyle.wdLineStyleNone;                           
            Table2.Borders[WdBorderType.wdBorderDiagonalUp].LineStyle = WdLineStyle.wdLineStyleNone;                            
            Table2.Borders[WdBorderType.wdBorderHorizontal].LineStyle = WdLineStyle.wdLineStyleNone;                             
            Table2.Borders[WdBorderType.wdBorderLeft].LineStyle = WdLineStyle.wdLineStyleNone;                                   
            Table2.Borders[WdBorderType.wdBorderRight].LineStyle = WdLineStyle.wdLineStyleNone;                                 
            Table2.Borders[WdBorderType.wdBorderTop].LineStyle = WdLineStyle.wdLineStyleSingle;                                  
            Table2.Borders[WdBorderType.wdBorderVertical].LineStyle = WdLineStyle.wdLineStyleNone;                               
            Table2.Borders[WdBorderType.wdBorderTop].LineWidth = WdLineWidth.wdLineWidth025pt;

            doc_sBaseDocument.Content.LanguageID = WdLanguageID.wdNoProofing;


            if (word.Version == "12.0")
            {
                doc_sBaseDocument.SaveAs(DestinationDocumentFileName);

            }
            else
                doc_sBaseDocument.SaveAs2(DestinationDocumentFileName, WdSaveFormat.wdFormatDocumentDefault); 

            doc_sBaseDocument.Close();                                                     
            word.Quit();                                                      

            
            return 0;
        }

        public static int JustOpenDocument_V2(String BaseDocumentFileName, String DestinationDocumentFileName, String DocumentCaption, String DocumentDate, String HistoryDate)
        {

            const int WordTrue = -1;
            const int WordFalse = 0;

            if (File.Exists(BaseDocumentFileName) == false) return 1001;
            if (File.Exists(DestinationDocumentFileName) == true) return 1007;


            var word = new Microsoft.Office.Interop.Word.Application();

            try
            {
                word = new Microsoft.Office.Interop.Word.Application();
            }
            catch
            {
                return 1000;
            }


            word.Visible = false;
            word.ScreenUpdating = false;

            if ((word.Version == "11.0") || (word.Version == "10.0") || (word.Version == "9.0") || (word.Version == "8.0") || (word.Version == "7.0") || (word.Version == "6.0"))
            {
                // if Word is Lower thatn 2007
                word.Quit();
                return 5000;
            }


            var doc_sBaseDocument = word.Documents.Open(FileName: BaseDocumentFileName, ConfirmConversions: false, ReadOnly: true);
            doc_sBaseDocument.ActiveWindow.View.ReadingLayout = false;
            // Delete All Headers and Footers From Document   

            foreach (Section wordSection in doc_sBaseDocument.Sections)
            {
                wordSection.Headers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.Delete();
                wordSection.Footers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.Delete();

                if (wordSection.PageSetup.OddAndEvenPagesHeaderFooter == 1)
                {
                    wordSection.Headers[WdHeaderFooterIndex.wdHeaderFooterEvenPages].Range.Delete();
                    wordSection.Footers[WdHeaderFooterIndex.wdHeaderFooterEvenPages].Range.Delete();
                }

                if (wordSection.PageSetup.DifferentFirstPageHeaderFooter == 1)
                {
                    wordSection.Headers[WdHeaderFooterIndex.wdHeaderFooterFirstPage].Range.Delete();
                    wordSection.Footers[WdHeaderFooterIndex.wdHeaderFooterFirstPage].Range.Delete();
                }
            }

            doc_sBaseDocument.Activate();

            var HeaderRange = doc_sBaseDocument.Sections[1].Headers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
            var Table1 = HeaderRange.Tables.Add(HeaderRange, 1, 2);
            Table1.Cell(1, 1).Range.Text = "Codex DS";

            var CellRange = Table1.Cell(1, 2).Range;

            CellRange.Collapse(WdCollapseDirection.wdCollapseStart);

            var Filed2 = doc_sBaseDocument.Fields.Add(CellRange, WdFieldType.wdFieldNumPages);
            CellRange.InsertBefore(" of ");
            CellRange.Collapse(WdCollapseDirection.wdCollapseStart);

            var Filed1 = doc_sBaseDocument.Fields.Add(CellRange, WdFieldType.wdFieldPage);

            CellRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
            CellRange.LanguageID = WdLanguageID.wdNoProofing;


            Table1.Borders[WdBorderType.wdBorderBottom].LineStyle = WdLineStyle.wdLineStyleSingle;
            Table1.Borders[WdBorderType.wdBorderDiagonalDown].LineStyle = WdLineStyle.wdLineStyleNone;
            Table1.Borders[WdBorderType.wdBorderDiagonalUp].LineStyle = WdLineStyle.wdLineStyleNone;
            Table1.Borders[WdBorderType.wdBorderHorizontal].LineStyle = WdLineStyle.wdLineStyleNone;
            Table1.Borders[WdBorderType.wdBorderLeft].LineStyle = WdLineStyle.wdLineStyleNone;
            Table1.Borders[WdBorderType.wdBorderRight].LineStyle = WdLineStyle.wdLineStyleNone;
            Table1.Borders[WdBorderType.wdBorderTop].LineStyle = WdLineStyle.wdLineStyleNone;
            Table1.Borders[WdBorderType.wdBorderVertical].LineStyle = WdLineStyle.wdLineStyleNone;
            Table1.Borders[WdBorderType.wdBorderBottom].LineWidth = WdLineWidth.wdLineWidth025pt;


            var FooterRange = doc_sBaseDocument.Sections[1].Footers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
            var Table2 = HeaderRange.Tables.Add(FooterRange, 2, 2);

            var Footer_Cell_Left_Range = Table2.Cell(1, 1).Range;
            Footer_Cell_Left_Range.Text = DocumentCaption;
            Footer_Cell_Left_Range.Font.Name = "Sylfaen";
            Footer_Cell_Left_Range.Font.Size = 8.0f;
            Footer_Cell_Left_Range.Font.Bold = WordFalse;
            Footer_Cell_Left_Range.Font.Italic = WordFalse;
            Footer_Cell_Left_Range.LanguageID = WdLanguageID.wdNoProofing;

            var Footer_Cell_Right_Range = Table2.Cell(1, 2).Range;
            Footer_Cell_Right_Range.Text = DocumentDate;
            Footer_Cell_Right_Range.Font.Name = "Sylfaen";
            Footer_Cell_Right_Range.Font.Size = 8.0f;
            Footer_Cell_Right_Range.Font.Bold = WordFalse;
            Footer_Cell_Right_Range.Font.Italic = WordFalse;
            Footer_Cell_Right_Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
            Footer_Cell_Right_Range.LanguageID = WdLanguageID.wdNoProofing;

            var Footer_Cell_Right_Range2 = Table2.Cell(2, 2).Range;
            Footer_Cell_Right_Range2.Text = HistoryDate;
            Footer_Cell_Right_Range2.Font.Name = "Sylfaen";
            Footer_Cell_Right_Range2.Font.Size = 8.0f;
            Footer_Cell_Right_Range2.Font.Bold = WordFalse;
            Footer_Cell_Right_Range2.Font.Italic = WordFalse;
            Footer_Cell_Right_Range2.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
            Footer_Cell_Right_Range2.LanguageID = WdLanguageID.wdNoProofing;


            Table2.Cell(1, 1).Range.ParagraphFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;
            Table2.Cell(1, 2).Range.ParagraphFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;
            Table2.Cell(2, 1).Range.ParagraphFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;
            Table2.Cell(2, 2).Range.ParagraphFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;

            Table2.Cell(1, 1).Range.ParagraphFormat.SpaceAfter = 0;
            Table2.Cell(1, 1).Range.ParagraphFormat.SpaceBefore = 0;

            Table2.Cell(1, 2).Range.ParagraphFormat.SpaceAfter = 0;
            Table2.Cell(1, 2).Range.ParagraphFormat.SpaceBefore = 0;

            Table2.Cell(2, 1).Range.ParagraphFormat.SpaceAfter = 0;
            Table2.Cell(2, 1).Range.ParagraphFormat.SpaceBefore = 0;

            Table2.Cell(2, 2).Range.ParagraphFormat.SpaceAfter = 0;
            Table2.Cell(2, 2).Range.ParagraphFormat.SpaceBefore = 0;

            Table1.Cell(1, 1).Range.ParagraphFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;
            Table1.Cell(1, 2).Range.ParagraphFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;

            Table1.Cell(1, 1).Range.ParagraphFormat.SpaceAfter = 0;
            Table1.Cell(1, 1).Range.ParagraphFormat.SpaceBefore = 0;

            Table1.Cell(1, 2).Range.ParagraphFormat.SpaceAfter = 0;
            Table1.Cell(1, 2).Range.ParagraphFormat.SpaceBefore = 0;

            Table2.Borders[WdBorderType.wdBorderBottom].LineStyle = WdLineStyle.wdLineStyleNone;
            Table2.Borders[WdBorderType.wdBorderDiagonalDown].LineStyle = WdLineStyle.wdLineStyleNone;
            Table2.Borders[WdBorderType.wdBorderDiagonalUp].LineStyle = WdLineStyle.wdLineStyleNone;
            Table2.Borders[WdBorderType.wdBorderHorizontal].LineStyle = WdLineStyle.wdLineStyleNone;
            Table2.Borders[WdBorderType.wdBorderLeft].LineStyle = WdLineStyle.wdLineStyleNone;
            Table2.Borders[WdBorderType.wdBorderRight].LineStyle = WdLineStyle.wdLineStyleNone;
            Table2.Borders[WdBorderType.wdBorderTop].LineStyle = WdLineStyle.wdLineStyleSingle;
            Table2.Borders[WdBorderType.wdBorderVertical].LineStyle = WdLineStyle.wdLineStyleNone;
            Table2.Borders[WdBorderType.wdBorderTop].LineWidth = WdLineWidth.wdLineWidth025pt;

            doc_sBaseDocument.Content.LanguageID = WdLanguageID.wdNoProofing;

            doc_sBaseDocument.Saved = true;
            

            return 0;
        }

        public static int ViewSideBySide()
        {
            return 0;
        }

        public static int CompareTwoDocumentScript(String BaseDocumentFileName, String UpdateDocumentFileName, String DestinationDocumentFileName, String DocumentCaption, String DocumentDate, String HistoryDate)
        {
            
            const int WordTrue = -1;
            const int WordFalse = 0;

            if (File.Exists(BaseDocumentFileName) == false) return 1001;
            if (File.Exists(UpdateDocumentFileName) == false) return 1002;

            var word = new Microsoft.Office.Interop.Word.Application();

            try
            {
                word = new Microsoft.Office.Interop.Word.Application();
            }
            catch
            {
                return 1000;
            }



            word.Visible = false;
            word.ScreenUpdating = false;

            if ((word.Version == "11.0") || (word.Version == "10.0") || (word.Version == "9.0") || (word.Version == "8.0") || (word.Version == "7.0") || (word.Version == "6.0"))
            {
                // if Word is Lower thatn 2007
                word.Quit();
                return 5000;
            }

            var doc_sBaseDocument = word.Documents.Open(FileName: BaseDocumentFileName, ConfirmConversions: false, ReadOnly: true);
            var doc_sUpdatedDocument = word.Documents.Open(FileName: UpdateDocumentFileName, ConfirmConversions : false, ReadOnly : true);

            String CodexAuthor = "Codex";

            word.CompareDocuments(OriginalDocument  : doc_sBaseDocument, RevisedDocument : doc_sUpdatedDocument, 
                                  Destination : WdCompareDestination.wdCompareDestinationNew, Granularity : WdGranularity.wdGranularityWordLevel, 
                                  CompareFormatting : false,  CompareCaseChanges : true, CompareWhitespace : false, CompareTables : true, 
                                  CompareHeaders : false, CompareFootnotes : false, CompareTextboxes : true, CompareFields : false, 
                                  CompareComments : false, CompareMoves : true, RevisedAuthor : CodexAuthor, IgnoreAllComparisonWarnings : true);

            word.ActiveWindow.View.ReadingLayout = false;  
            var destination = word.ActiveDocument;


            destination.Final = false;                                                               
            destination.TrackRevisions = false;                                                        
            destination.ShowRevisions = true;                                                         
            destination.PrintRevisions = true;                                                       
            destination.TrackFormatting = false;

            foreach (Section wordSection in destination.Sections)
            {
                wordSection.Headers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.Delete();
                wordSection.Footers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.Delete();

                if (wordSection.PageSetup.OddAndEvenPagesHeaderFooter == 1)
                {
                    wordSection.Headers[WdHeaderFooterIndex.wdHeaderFooterEvenPages].Range.Delete();
                    wordSection.Footers[WdHeaderFooterIndex.wdHeaderFooterEvenPages].Range.Delete();
                }

                if (wordSection.PageSetup.DifferentFirstPageHeaderFooter == 1)
                {
                    wordSection.Headers[WdHeaderFooterIndex.wdHeaderFooterFirstPage].Range.Delete();
                    wordSection.Footers[WdHeaderFooterIndex.wdHeaderFooterFirstPage].Range.Delete();
                }
            }

            destination.Activate();

            var HeaderRange = destination.Sections[1].Headers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
            var Table1 = HeaderRange.Tables.Add(HeaderRange, 1, 2);
            Table1.Cell(1, 1).Range.Text = "Codex DS";

            var CellRange = Table1.Cell(1, 2).Range;

            CellRange.Collapse(WdCollapseDirection.wdCollapseStart);
            var Filed2 = destination.Fields.Add(CellRange, WdFieldType.wdFieldNumPages);
            CellRange.InsertBefore(" of ");
            CellRange.Collapse(WdCollapseDirection.wdCollapseStart);

            var Filed1 = destination.Fields.Add(CellRange, WdFieldType.wdFieldPage);

            CellRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
            CellRange.LanguageID = WdLanguageID.wdNoProofing;
            Table1.Borders[WdBorderType.wdBorderBottom].LineStyle = WdLineStyle.wdLineStyleSingle;
            Table1.Borders[WdBorderType.wdBorderDiagonalDown].LineStyle = WdLineStyle.wdLineStyleNone;
            Table1.Borders[WdBorderType.wdBorderDiagonalUp].LineStyle = WdLineStyle.wdLineStyleNone;
            Table1.Borders[WdBorderType.wdBorderHorizontal].LineStyle = WdLineStyle.wdLineStyleNone;
            Table1.Borders[WdBorderType.wdBorderLeft].LineStyle = WdLineStyle.wdLineStyleNone;
            Table1.Borders[WdBorderType.wdBorderRight].LineStyle = WdLineStyle.wdLineStyleNone;
            Table1.Borders[WdBorderType.wdBorderTop].LineStyle = WdLineStyle.wdLineStyleNone;
            Table1.Borders[WdBorderType.wdBorderVertical].LineStyle = WdLineStyle.wdLineStyleNone;
            Table1.Borders[WdBorderType.wdBorderBottom].LineWidth = WdLineWidth.wdLineWidth025pt;

            var FooterRange = destination.Sections[1].Footers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
            var Table2 = HeaderRange.Tables.Add(FooterRange, 2, 2);

            var Footer_Cell_Left_Range = Table2.Cell(1, 1).Range;
            Footer_Cell_Left_Range.Text = DocumentCaption;
            Footer_Cell_Left_Range.Font.Name = "Sylfaen";
            Footer_Cell_Left_Range.Font.Size = 8.0f;
            Footer_Cell_Left_Range.Font.Bold = WordFalse;
            Footer_Cell_Left_Range.Font.Italic = WordFalse;
            Footer_Cell_Left_Range.LanguageID = WdLanguageID.wdNoProofing;

            var Footer_Cell_Right_Range = Table2.Cell(1, 2).Range;
            Footer_Cell_Right_Range.Text = DocumentDate;
            Footer_Cell_Right_Range.Font.Name = "Sylfaen";
            Footer_Cell_Right_Range.Font.Size = 8.0f;
            Footer_Cell_Right_Range.Font.Bold = WordFalse;
            Footer_Cell_Right_Range.Font.Italic = WordFalse;
            Footer_Cell_Right_Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
            Footer_Cell_Right_Range.LanguageID = WdLanguageID.wdNoProofing;

            var Footer_Cell_Right_Range2 = Table2.Cell(2, 2).Range;
            Footer_Cell_Right_Range2.Text = HistoryDate;
            Footer_Cell_Right_Range2.Font.Name = "Sylfaen";
            Footer_Cell_Right_Range2.Font.Size = 8.0f;
            Footer_Cell_Right_Range2.Font.Bold = WordFalse;
            Footer_Cell_Right_Range2.Font.Italic = WordFalse;
            Footer_Cell_Right_Range2.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
            Footer_Cell_Right_Range2.LanguageID = WdLanguageID.wdNoProofing;

            Table2.Cell(1, 1).Range.ParagraphFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;
            Table2.Cell(1, 2).Range.ParagraphFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;
            Table2.Cell(2, 1).Range.ParagraphFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;
            Table2.Cell(2, 2).Range.ParagraphFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;

            Table2.Cell(1, 1).Range.ParagraphFormat.SpaceAfter = 0;
            Table2.Cell(1, 1).Range.ParagraphFormat.SpaceBefore = 0;

            Table2.Cell(1, 2).Range.ParagraphFormat.SpaceAfter = 0;
            Table2.Cell(1, 2).Range.ParagraphFormat.SpaceBefore = 0;

            Table2.Cell(2, 1).Range.ParagraphFormat.SpaceAfter = 0;
            Table2.Cell(2, 1).Range.ParagraphFormat.SpaceBefore = 0;

            Table2.Cell(2, 2).Range.ParagraphFormat.SpaceAfter = 0;
            Table2.Cell(2, 2).Range.ParagraphFormat.SpaceBefore = 0;

            Table1.Cell(1, 1).Range.ParagraphFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;
            Table1.Cell(1, 2).Range.ParagraphFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;

            Table1.Cell(1, 1).Range.ParagraphFormat.SpaceAfter = 0;
            Table1.Cell(1, 1).Range.ParagraphFormat.SpaceBefore = 0;

            Table1.Cell(1, 2).Range.ParagraphFormat.SpaceAfter = 0;
            Table1.Cell(1, 2).Range.ParagraphFormat.SpaceBefore = 0;

            Table2.Borders[WdBorderType.wdBorderBottom].LineStyle = WdLineStyle.wdLineStyleNone;
            Table2.Borders[WdBorderType.wdBorderDiagonalDown].LineStyle = WdLineStyle.wdLineStyleNone;
            Table2.Borders[WdBorderType.wdBorderDiagonalUp].LineStyle = WdLineStyle.wdLineStyleNone;
            Table2.Borders[WdBorderType.wdBorderHorizontal].LineStyle = WdLineStyle.wdLineStyleNone;
            Table2.Borders[WdBorderType.wdBorderLeft].LineStyle = WdLineStyle.wdLineStyleNone;
            Table2.Borders[WdBorderType.wdBorderRight].LineStyle = WdLineStyle.wdLineStyleNone;
            Table2.Borders[WdBorderType.wdBorderTop].LineStyle = WdLineStyle.wdLineStyleSingle;
            Table2.Borders[WdBorderType.wdBorderVertical].LineStyle = WdLineStyle.wdLineStyleNone;
            Table2.Borders[WdBorderType.wdBorderTop].LineWidth = WdLineWidth.wdLineWidth025pt;

            doc_sBaseDocument.Close();
            doc_sUpdatedDocument.Close();

            destination.Content.LanguageID = WdLanguageID.wdNoProofing;
            destination.Saved = true;
            destination.TrackRevisions = false;
      
            destination.ActiveWindow.ShowSourceDocuments = WdShowSourceDocuments.wdShowSourceDocumentsNone;
            if ((word.Version != "14.0") && (word.Version != "12.0")) // Abve Office 2013
            {
                destination.ActiveWindow.View.RevisionsFilter.Markup = WdRevisionsMarkup.wdRevisionsMarkupAll;
            } 
            destination.ActiveWindow.View.ShowRevisionsAndComments = true;

                    
            if (word.Version == "12.0")
            {
                destination.SaveAs(DestinationDocumentFileName);

            }
            else
                destination.SaveAs2(DestinationDocumentFileName, WdSaveFormat.wdFormatDocumentDefault);


            destination.Close();
            word.Quit();

            return 0; 
        }

        public static int CompareTwoDocumentScriptV2(String BaseDocumentFileName, String UpdateDocumentFileName, String ComparedDocumentFileName, String DocumentCaption, String DocumentDate, String HistoryDate,
                                                     int cGranularity, int cShowChangesIn, int cSourceDocuments, int cRevisionPanel, int cMode)
        {

            const int WordTrue = -1;
            const int WordFalse = 0;

            if (File.Exists(BaseDocumentFileName) == false) return 1001;
            if (File.Exists(UpdateDocumentFileName) == false) return 1002;

            var word = new Microsoft.Office.Interop.Word.Application();

            try
            {
                word = new Microsoft.Office.Interop.Word.Application();
            }
            catch
            {
                return 1000;
            }



            word.Visible = false;
            word.ScreenUpdating = false;

            if ((word.Version == "11.0") || (word.Version == "10.0") || (word.Version == "9.0") || (word.Version == "8.0") || (word.Version == "7.0") || (word.Version == "6.0"))
            {
                // if Word is Lower thatn 2007
                word.Quit();
                return 5000;
            }

            var doc_sBaseDocument = word.Documents.Open(FileName: BaseDocumentFileName, ConfirmConversions: false, ReadOnly: true);
            var doc_sUpdatedDocument = word.Documents.Open(FileName: UpdateDocumentFileName, ConfirmConversions: false, ReadOnly: true);

            String CodexAuthor = "Codex";

            var pGranularity = WdGranularity.wdGranularityWordLevel;
            if (cGranularity == 0) pGranularity = WdGranularity.wdGranularityCharLevel;

            var pDestiniton = WdCompareDestination.wdCompareDestinationNew;
            switch (cShowChangesIn)
            {
                case 0: pDestiniton = WdCompareDestination.wdCompareDestinationOriginal; break;
                case 1: pDestiniton = WdCompareDestination.wdCompareDestinationRevised; break;
            }

            word.CompareDocuments(OriginalDocument: doc_sBaseDocument, RevisedDocument: doc_sUpdatedDocument,
                                  Destination: pDestiniton, Granularity: pGranularity,
                                  CompareFormatting: false, CompareCaseChanges: true, CompareWhitespace: false, CompareTables: true,
                                  CompareHeaders: false, CompareFootnotes: false, CompareTextboxes: true, CompareFields: false,
                                  CompareComments: false, CompareMoves: true, RevisedAuthor: CodexAuthor, IgnoreAllComparisonWarnings: true);

            word.ActiveWindow.View.ReadingLayout = false;
            var destination = word.ActiveDocument;


            destination.Final = false;
            destination.TrackRevisions = false;
            destination.ShowRevisions = true;
            destination.PrintRevisions = true;
            destination.TrackFormatting = false;

            foreach (Section wordSection in destination.Sections)
            {
                wordSection.Headers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.Delete();
                wordSection.Footers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.Delete();

                if (wordSection.PageSetup.OddAndEvenPagesHeaderFooter == 1)
                {
                    wordSection.Headers[WdHeaderFooterIndex.wdHeaderFooterEvenPages].Range.Delete();
                    wordSection.Footers[WdHeaderFooterIndex.wdHeaderFooterEvenPages].Range.Delete();
                }

                if (wordSection.PageSetup.DifferentFirstPageHeaderFooter == 1)
                {
                    wordSection.Headers[WdHeaderFooterIndex.wdHeaderFooterFirstPage].Range.Delete();
                    wordSection.Footers[WdHeaderFooterIndex.wdHeaderFooterFirstPage].Range.Delete();
                }
            }

            destination.Activate();

            var HeaderRange = destination.Sections[1].Headers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
            var Table1 = HeaderRange.Tables.Add(HeaderRange, 1, 2);
            Table1.Cell(1, 1).Range.Text = "Codex DS";

            var CellRange = Table1.Cell(1, 2).Range;

            CellRange.Collapse(WdCollapseDirection.wdCollapseStart);
            var Filed2 = destination.Fields.Add(CellRange, WdFieldType.wdFieldNumPages);
            CellRange.InsertBefore(" of ");
            CellRange.Collapse(WdCollapseDirection.wdCollapseStart);

            var Filed1 = destination.Fields.Add(CellRange, WdFieldType.wdFieldPage);

            CellRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
            CellRange.LanguageID = WdLanguageID.wdNoProofing;
            Table1.Borders[WdBorderType.wdBorderBottom].LineStyle = WdLineStyle.wdLineStyleSingle;
            Table1.Borders[WdBorderType.wdBorderDiagonalDown].LineStyle = WdLineStyle.wdLineStyleNone;
            Table1.Borders[WdBorderType.wdBorderDiagonalUp].LineStyle = WdLineStyle.wdLineStyleNone;
            Table1.Borders[WdBorderType.wdBorderHorizontal].LineStyle = WdLineStyle.wdLineStyleNone;
            Table1.Borders[WdBorderType.wdBorderLeft].LineStyle = WdLineStyle.wdLineStyleNone;
            Table1.Borders[WdBorderType.wdBorderRight].LineStyle = WdLineStyle.wdLineStyleNone;
            Table1.Borders[WdBorderType.wdBorderTop].LineStyle = WdLineStyle.wdLineStyleNone;
            Table1.Borders[WdBorderType.wdBorderVertical].LineStyle = WdLineStyle.wdLineStyleNone;
            Table1.Borders[WdBorderType.wdBorderBottom].LineWidth = WdLineWidth.wdLineWidth025pt;

            var FooterRange = destination.Sections[1].Footers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
            var Table2 = HeaderRange.Tables.Add(FooterRange, 2, 2);

            var Footer_Cell_Left_Range = Table2.Cell(1, 1).Range;
            Footer_Cell_Left_Range.Text = DocumentCaption;
            Footer_Cell_Left_Range.Font.Name = "Sylfaen";
            Footer_Cell_Left_Range.Font.Size = 8.0f;
            Footer_Cell_Left_Range.Font.Bold = WordFalse;
            Footer_Cell_Left_Range.Font.Italic = WordFalse;
            Footer_Cell_Left_Range.LanguageID = WdLanguageID.wdNoProofing;

            var Footer_Cell_Right_Range = Table2.Cell(1, 2).Range;
            Footer_Cell_Right_Range.Text = DocumentDate;
            Footer_Cell_Right_Range.Font.Name = "Sylfaen";
            Footer_Cell_Right_Range.Font.Size = 8.0f;
            Footer_Cell_Right_Range.Font.Bold = WordFalse;
            Footer_Cell_Right_Range.Font.Italic = WordFalse;
            Footer_Cell_Right_Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
            Footer_Cell_Right_Range.LanguageID = WdLanguageID.wdNoProofing;

            var Footer_Cell_Right_Range2 = Table2.Cell(2, 2).Range;
            Footer_Cell_Right_Range2.Text = HistoryDate;
            Footer_Cell_Right_Range2.Font.Name = "Sylfaen";
            Footer_Cell_Right_Range2.Font.Size = 8.0f;
            Footer_Cell_Right_Range2.Font.Bold = WordFalse;
            Footer_Cell_Right_Range2.Font.Italic = WordFalse;
            Footer_Cell_Right_Range2.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
            Footer_Cell_Right_Range2.LanguageID = WdLanguageID.wdNoProofing;

            Table2.Cell(1, 1).Range.ParagraphFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;
            Table2.Cell(1, 2).Range.ParagraphFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;
            Table2.Cell(2, 1).Range.ParagraphFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;
            Table2.Cell(2, 2).Range.ParagraphFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;

            Table2.Cell(1, 1).Range.ParagraphFormat.SpaceAfter = 0;
            Table2.Cell(1, 1).Range.ParagraphFormat.SpaceBefore = 0;

            Table2.Cell(1, 2).Range.ParagraphFormat.SpaceAfter = 0;
            Table2.Cell(1, 2).Range.ParagraphFormat.SpaceBefore = 0;

            Table2.Cell(2, 1).Range.ParagraphFormat.SpaceAfter = 0;
            Table2.Cell(2, 1).Range.ParagraphFormat.SpaceBefore = 0;

            Table2.Cell(2, 2).Range.ParagraphFormat.SpaceAfter = 0;
            Table2.Cell(2, 2).Range.ParagraphFormat.SpaceBefore = 0;

            Table1.Cell(1, 1).Range.ParagraphFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;
            Table1.Cell(1, 2).Range.ParagraphFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;

            Table1.Cell(1, 1).Range.ParagraphFormat.SpaceAfter = 0;
            Table1.Cell(1, 1).Range.ParagraphFormat.SpaceBefore = 0;

            Table1.Cell(1, 2).Range.ParagraphFormat.SpaceAfter = 0;
            Table1.Cell(1, 2).Range.ParagraphFormat.SpaceBefore = 0;

            Table2.Borders[WdBorderType.wdBorderBottom].LineStyle = WdLineStyle.wdLineStyleNone;
            Table2.Borders[WdBorderType.wdBorderDiagonalDown].LineStyle = WdLineStyle.wdLineStyleNone;
            Table2.Borders[WdBorderType.wdBorderDiagonalUp].LineStyle = WdLineStyle.wdLineStyleNone;
            Table2.Borders[WdBorderType.wdBorderHorizontal].LineStyle = WdLineStyle.wdLineStyleNone;
            Table2.Borders[WdBorderType.wdBorderLeft].LineStyle = WdLineStyle.wdLineStyleNone;
            Table2.Borders[WdBorderType.wdBorderRight].LineStyle = WdLineStyle.wdLineStyleNone;
            Table2.Borders[WdBorderType.wdBorderTop].LineStyle = WdLineStyle.wdLineStyleSingle;
            Table2.Borders[WdBorderType.wdBorderVertical].LineStyle = WdLineStyle.wdLineStyleNone;
            Table2.Borders[WdBorderType.wdBorderTop].LineWidth = WdLineWidth.wdLineWidth025pt;

            doc_sBaseDocument.Close();
            doc_sUpdatedDocument.Close();

            destination.Content.LanguageID = WdLanguageID.wdNoProofing;
            destination.Saved = true;
            destination.TrackRevisions = false;


            var pShowSourceDocuments = WdShowSourceDocuments.wdShowSourceDocumentsNone;


            switch (cSourceDocuments)
            {
                case 0: pShowSourceDocuments = WdShowSourceDocuments.wdShowSourceDocumentsNone; break;
                case 1: pShowSourceDocuments = WdShowSourceDocuments.wdShowSourceDocumentsOriginal; break;
                case 2: pShowSourceDocuments = WdShowSourceDocuments.wdShowSourceDocumentsRevised; break;
                case 3: pShowSourceDocuments = WdShowSourceDocuments.wdShowSourceDocumentsBoth; break;
            }


            destination.ActiveWindow.ShowSourceDocuments = pShowSourceDocuments;


            if ((word.Version != "14.0") && (word.Version != "12.0")) // Abve Office 2013
            {
                destination.ActiveWindow.View.RevisionsFilter.Markup = WdRevisionsMarkup.wdRevisionsMarkupAll;
            }




            destination.ActiveWindow.View.ShowRevisionsAndComments = true;

            if ((word.Version != "14.0") && (word.Version != "12.0")) // Office 2013 or Office 2016
            {
                var pMode = WdRevisionsMode.wdBalloonRevisions;

                if (cMode == 1)
                {
                    pMode = WdRevisionsMode.wdInLineRevisions;
                }

                destination.ActiveWindow.View.RevisionsMode = pMode;// WdRevisionsMode.wdBalloonRevisions;// wdInLineRevisions;
            }

            var pRevisionPanel = WdSpecialPane.wdPaneRevisionsVert;

            switch (cRevisionPanel)
            {
                case 0:
                    {
                        pRevisionPanel = WdSpecialPane.wdPaneNone;
                        destination.ActiveWindow.View.ShowRevisionsAndComments = false;

                    }
                    break;
                case 1: pRevisionPanel = WdSpecialPane.wdPaneRevisionsVert; break;
                case 2: pRevisionPanel = WdSpecialPane.wdPaneRevisionsHoriz; break;
            }


           destination.ActiveWindow.View.SplitSpecial = pRevisionPanel;

            if ((word.Version != "14.0") && (word.Version != "12.0")) // Office 2013 or Office 2016
            {
                destination.ActiveWindow.View.RevisionsFilter.Markup = WdRevisionsMarkup.wdRevisionsMarkupAll;
            }

            if ((word.Version != "11.0") && (word.Version != "10.0")) // Office 2010 or Office 2007
            {
                destination.ActiveWindow.View.ShowRevisionsAndComments = true;
                destination.ActiveWindow.View.RevisionsView = WdRevisionsView.wdRevisionsViewFinal;
            }

        

            if (word.Version == "12.0")
            {
                destination.SaveAs(ComparedDocumentFileName);

            }
            else
                destination.SaveAs2(ComparedDocumentFileName, WdSaveFormat.wdFormatDocumentDefault);

            word.Visible = true;
            word.ScreenUpdating = true;
            destination.Activate();
            word.Activate();
            word.WindowState = WdWindowState.wdWindowStateNormal;
            
            //destination.Close();
            //word.Quit();

            return 0;
        }

    }
}
