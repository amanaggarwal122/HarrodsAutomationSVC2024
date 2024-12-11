using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_Integration.Scripted.Ado.Interfaces;
using TAF_Integration.Scripted.Ado.Models;

namespace TAF_Integration.Scripted.Ado.Implementations
{
    public class WorkItemManager : IWorkItemManager
    {
        IAdoClient _adoClient = null;

        public WorkItemManager(IAdoClient ADOClient)
        {
            _adoClient = ADOClient;
        }

        public WorkItem CreateWorkItem(List<WorkItem> workItem)
        {
            return _adoClient.CreateWorkItem(workItem);
        }

        public Attachment AddWorkItemAttachment(Attachment attachment)
        {
            return _adoClient.AddWorkItemAttachment(attachment);
        }

        public WorkItem MapAttachmentToWorkItem(WorkItem workItem)
        {
            return _adoClient.MapAttachmentToWorkItem(workItem);
        }

    }
}
