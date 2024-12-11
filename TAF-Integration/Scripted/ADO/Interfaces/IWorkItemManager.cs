using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_Integration.Scripted.Ado.Models;

namespace TAF_Integration.Scripted.Ado.Interfaces
{
    public interface IWorkItemManager
    {
        Attachment AddWorkItemAttachment(Attachment attachment);

        WorkItem MapAttachmentToWorkItem(WorkItem defect);

        WorkItem CreateWorkItem(List<WorkItem> workItem);
    }
}
