﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using nhs.itk.hl7v3.rim;
using System.Xml.Serialization;
using nhs.itk.hl7v3.datatypes;
using nhs.itk.hl7v3.xml;

namespace nhs.itk.hl7v3.cda.classes
{
    internal class r_assignedCustodian : RoleClass
    {
        internal string templateId { get; set; }
        internal string templateText { get; set; }
        internal e_organisation representedOrganisation;

        internal r_assignedCustodian()
            : base()
        { }

        internal r_assignedCustodian(string classCode)
            : base(classCode)
        { }

        internal void InitOrganisation()
        {
            if (representedOrganisation == null)
            {
                representedOrganisation = new e_organisation("ORG", "INSTANCE");
            }
        }

        internal new void AddId(string root, string extension)
        {
            base.AddId(root, extension);
        }

        #region XML Serialization Members

        internal void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("classCode", ClassCode);

            its.TemplateSignpost(templateId + "#" + templateText, writer);
            writeXML(writer);

            if (representedOrganisation != null)
            {
                writer.WriteStartElement("representedCustodianOrganization");
                representedOrganisation.TemplateId = templateId;
                representedOrganisation.TemplateText = "representedCustodianOrganization";
                representedOrganisation.WriteXml(writer);
                writer.WriteEndElement();
            }
        }

        #endregion
    }
}
