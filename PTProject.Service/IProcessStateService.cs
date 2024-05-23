using PTProject.Data;

namespace PTProject.Service
{
    public interface IProcessStateService
    {
        void AddProcessState(ProcessState processState);
        ProcessState GetProcessState(int id);
        void UpdateProcessState(ProcessState updatedProcessState, string eventType);
        void DeleteProcessState(int id);
    }
}
