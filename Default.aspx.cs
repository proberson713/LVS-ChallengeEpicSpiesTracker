using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string[] allAssetNames = new string[0];
            int[] totalNumberOfElectionsRigged = new int[0];
            int[] totalActsOfSubterfuge = new int[0];

            ViewState.Add("AssetNames", allAssetNames);
            ViewState.Add("TotalElectionsRigged", totalNumberOfElectionsRigged);
            ViewState.Add("ActsOfSubterfuge", totalActsOfSubterfuge);
        }
    }
    protected void addAssetButton_Click(object sender, EventArgs e)
    {

        string[] allAssetNames = (string[])ViewState["AssetNames"];
        int[] totalNumberOfElectionsRigged = (int[])ViewState["TotalElectionsRigged"];
        int[] totalActsOfSubterfuge = (int[])ViewState["ActsOfSubterfuge"];

        int newArrayLength = allAssetNames.Length + 1;

        Array.Resize(ref allAssetNames, newArrayLength);
        Array.Resize(ref totalNumberOfElectionsRigged, newArrayLength);
        Array.Resize(ref totalActsOfSubterfuge, newArrayLength);

        int newIndex = allAssetNames.GetUpperBound(0);
        allAssetNames[newIndex] = assetNameTextBox.Text;
        totalNumberOfElectionsRigged[newIndex] = int.Parse(electionsRiggedTextBox.Text);
        totalActsOfSubterfuge[newIndex] = int.Parse(actsOfSubterfugePerformedTextBox.Text);

        ViewState["AssetNames"] = allAssetNames;
        ViewState["TotalElectionsRigged"] = totalNumberOfElectionsRigged;
        ViewState["ActsOfSubterfuge"] = totalActsOfSubterfuge;


        string currentAssetName = assetNameTextBox.Text;
        int currentNumberOfElectionsRigged = int.Parse(electionsRiggedTextBox.Text);
        int currentNumberOfActsOfSubterfugePerformed = int.Parse(actsOfSubterfugePerformedTextBox.Text);

        AssetNameLabel.Text = string.Format("Total Elections Rigged: {0}<br /> Average Acts of Subterfuge Per Asset: {1:N2}<br /> (Last Asset you Added: {2})"
            , totalNumberOfElectionsRigged.Sum(), totalActsOfSubterfuge.Average(), allAssetNames[newIndex]);

        assetNameTextBox.Text = "";
        electionsRiggedTextBox.Text = "";
        actsOfSubterfugePerformedTextBox.Text = "";
            


    }
}