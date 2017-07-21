using System;
using NXOpen;

public class NX_Selection
{
    public static void Main(string[] args)
    {
        Session theSession = Session.GetSession();
        Part workPart = theSession.Parts.Work;

        Part displayPart = theSession.Parts.Display;
        
        NXObject[] objects1 = new NXObject[1];
        NXOpen.Features.Extrude extrude1 = (NXOpen.Features.Extrude)workPart.Features.FindObject("EXTRUDE(2)");

        Face face1 = (Face)extrude1.FindObject("FACE 140 {(10,-0,30) EXTRUDE(2)}");

        objects1[0] = face1;
        AttributePropertiesBuilder attributePropertiesBuilder1 = default(AttributePropertiesBuilder);
        attributePropertiesBuilder1 = theSession.AttributeManager.CreateAttributePropertiesBuilder(workPart, objects1, AttributePropertiesBuilder.OperationType.None);

        attributePropertiesBuilder1.IsArray = false;

        attributePropertiesBuilder1.IsArray = false;

        attributePropertiesBuilder1.IsArray = false;

        attributePropertiesBuilder1.DataType = AttributePropertiesBaseBuilder.DataTypeOptions.String;

        attributePropertiesBuilder1.Units = "MilliMeter";
        
        ObjectGeneralPropertiesBuilder objectGeneralPropertiesBuilder1 = default(ObjectGeneralPropertiesBuilder);
        objectGeneralPropertiesBuilder1 = workPart.PropertiesManager.CreateObjectGeneralPropertiesBuilder(objects1);

        SelectNXObjectList selectNXObjectList1 = default(SelectNXObjectList);
        selectNXObjectList1 = objectGeneralPropertiesBuilder1.SelectedObjects;

        objectGeneralPropertiesBuilder1.NameLocationSpecified = false;

        objectGeneralPropertiesBuilder1.Index = 1;
        
        attributePropertiesBuilder1.SetAttributeObjects(objects1);

        SelectNXObjectList selectNXObjectList2 = default(SelectNXObjectList);
        selectNXObjectList2 = objectGeneralPropertiesBuilder1.SelectedObjects;

        attributePropertiesBuilder1.Title = "NS_FACE";

        attributePropertiesBuilder1.StringValue = "ANSYS_NS_Name";
        
        bool changed1 = false;
        changed1 = attributePropertiesBuilder1.CreateAttribute();

        attributePropertiesBuilder1.Title = "";

        attributePropertiesBuilder1.IsArray = false;

        attributePropertiesBuilder1.StringValue = "";
        
        NXObject nXObject1 = default(NXObject);
        nXObject1 = attributePropertiesBuilder1.Commit();

        NXObject nXObject2 = default(NXObject);
        nXObject2 = objectGeneralPropertiesBuilder1.Commit();
                        
        attributePropertiesBuilder1.Destroy();

        objectGeneralPropertiesBuilder1.Destroy();
                
        PartSaveStatus partSaveStatus1 = default(PartSaveStatus);
        partSaveStatus1 = workPart.Save(BasePart.SaveComponents.True, BasePart.CloseAfterSave.False);

        partSaveStatus1.Dispose();
    }

    public static int GetUnloadOption(string dummy)
    {
        return NXOpen.UF.UFConstants.UF_UNLOAD_IMMEDIATELY;
    }
}
