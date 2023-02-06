int frameRate = 60;
int eventRate = 16;

List<dynamic> data = new List<dynamic>
{
    new {
        procedure = 1, type = "low-demand", event_number = 1, event_type = "audio", start_frame = 1, end_frame = eventRate + 1, trigger_frame = 5, trigger_outcome = 1
    },
    new {
        procedure = 1, type = "low-demand", event_number = 2, event_type = "audio", start_frame = 1, end_frame = eventRate + 1, trigger_frame = 5, trigger_outcome = 0
    },
        new {
        procedure = 1, type = "low-demand", event_number = 3, event_type = "audio", start_frame = 1, end_frame = eventRate + 1, trigger_frame = 8, trigger_outcome = 0
    },
        new {
        procedure = 1, type = "low-demand", event_number = 4, event_type = "audio", start_frame = 1, end_frame = eventRate + 1, trigger_frame = 5, trigger_outcome = 1
    },
        new {
        procedure = 1, type = "low-demand", event_number = 5, event_type = "audio", start_frame = 1, end_frame = eventRate + 1, trigger_frame = 4, trigger_outcome = 1
    },
        new {
        procedure = 1, type = "low-demand", event_number = 6, event_type = "audio", start_frame = 1, end_frame = eventRate + 1, trigger_frame = 3, trigger_outcome = 1
    },
        new {
        procedure = 1, type = "low-demand", event_number = 7, event_type = "audio", start_frame = 1, end_frame = eventRate + 1, trigger_frame = 4, trigger_outcome = 1
    },
            new {
        procedure = 1, type = "low-demand", event_number = 8, event_type = "audio", start_frame = 1, end_frame = eventRate + 1, trigger_frame = 5, trigger_outcome = 0
    },
            new {
        procedure = 1, type = "low-demand", event_number = 9, event_type = "audio", start_frame = 1, end_frame = eventRate + 1, trigger_frame = 5, trigger_outcome = 1
    },
            new {
        procedure = 1, type = "low-demand", event_number = 10, event_type = "audio", start_frame = 1, end_frame = eventRate + 1, trigger_frame = 7, trigger_outcome = 1
    },
            new {
        procedure = 1, type = "low-demand", event_number = 11, event_type = "audio", start_frame = 1, end_frame = eventRate + 1, trigger_frame = 6, trigger_outcome = 1
    },
            new {
        procedure = 1, type = "low-demand", event_number = 12, event_type = "audio", start_frame = 1, end_frame = eventRate + 1, trigger_frame = 5, trigger_outcome = 0
    },
    
};

List<int> trueActions = data.Where(action => (int)action.trigger_outcome == 1).Select(action => (int)action.trigger_outcome).ToList();

double Quickness = 0;
foreach (var action in trueActions)
{
    Quickness += action.trigger_frame - action.start_frame;
}
Quickness = Quickness / frameRate;

double Steadiness = trueActions.Count() / data.Count();

double Stability = Math.Dif(data, data + 1);
