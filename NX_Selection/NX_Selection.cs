using System;
using NXOpen;
using Snap;

public class NX_Selection
{
    public static void Main(string[] args)
    {
        //SelectObject();

        Session theSession = Session.GetSession();
        Part workPart = theSession.Parts.Work;

        Part displayPart = theSession.Parts.Display;

        NXOpen.Features.Extrude extrude1 = (NXOpen.Features.Extrude)workPart.Features.FindObject("EXTRUDE(2)");
        Face face1 = (Face)extrude1.FindObject("FACE 140 {(10,-0,30) EXTRUDE(2)}");

        NXObject[] objects1 = new NXObject[1];
        objects1[0] = face1;
        AnsysNamedSelection(theSession, workPart, objects1, "NS_FACE");

        //PartSaveStatus partSaveStatus1 = default(PartSaveStatus);
        //partSaveStatus1 = workPart.Save(BasePart.SaveComponents.True, BasePart.CloseAfterSave.False);

        //partSaveStatus1.Dispose();
    }

    private static void SelectObject()
    {        string cue = "Please select a line";
        var type = Snap.NX.ObjectTypes.Type.Face;

        var dialog = Snap.UI.Selection.SelectObjects(cue, type);
        var result = dialog.Show();
        foreach (var item in result.Objects)
        {
            item.Color = System.Drawing.Color.Red;
        }
    }

    private static void AnsysNamedSelection(Session theSession, Part workPart, NXObject[] objects1, string name)
    {
        AttributePropertiesBuilder attributePropertiesBuilder1 = default(AttributePropertiesBuilder);
        attributePropertiesBuilder1 = theSession.AttributeManager.CreateAttributePropertiesBuilder(workPart, objects1, AttributePropertiesBuilder.OperationType.None);

        attributePropertiesBuilder1.DataType = AttributePropertiesBaseBuilder.DataTypeOptions.String;

        attributePropertiesBuilder1.SetAttributeObjects(objects1);

        attributePropertiesBuilder1.Title = name;

        attributePropertiesBuilder1.StringValue = "ANSYS_NS_Name";

        bool changed1 = false;
        changed1 = attributePropertiesBuilder1.CreateAttribute();

        NXObject nXObject1 = default(NXObject);
        nXObject1 = attributePropertiesBuilder1.Commit();

        attributePropertiesBuilder1.Destroy();
    }

    public static int GetUnloadOption(string dummy)
    {
        return NXOpen.UF.UFConstants.UF_UNLOAD_IMMEDIATELY;
    }
}
