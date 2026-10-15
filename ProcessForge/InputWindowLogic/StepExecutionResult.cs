namespace ProcessForge.InputWindowLogic
{
    public enum StepActionResult
    {
        Continue,
        Break,
        Goto
    }

    public class StepExecutionResult
    {
        public StepActionResult Status { get; set; } = StepActionResult.Continue;
        public string? GotoTarget { get; set; }

        public static StepExecutionResult Continue() => new StepExecutionResult { Status = StepActionResult.Continue };
        public static StepExecutionResult Break() => new StepExecutionResult { Status = StepActionResult.Break };
        public static StepExecutionResult Goto(string target) => new StepExecutionResult { Status = StepActionResult.Goto, GotoTarget = target };
    }
}
