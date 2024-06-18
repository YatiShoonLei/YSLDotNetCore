using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace YSLDotNetCore.RestApiWithNLayer.Features.PickAPile
{
    [Route("api/[controller]")]
    [ApiController]
    public class PickAPileController : ControllerBase
    {
        private async Task<PickAPile> GetPickAPileAsync()
        {
            string jsonStr = await System.IO.File.ReadAllTextAsync("PickAPile.json");
            var model = JsonConvert.DeserializeObject<PickAPile>(jsonStr);
            return model;
        }

        [HttpGet("Questions")]
        public async Task<IActionResult> Question()
        {
            var model = await GetPickAPileAsync();
            return Ok(model.Questions);
        }

        [HttpGet("Answers")]
        public async Task<IActionResult> Answer()
        {
            var model = await GetPickAPileAsync();
            return Ok(model.Answers);
        }

        [HttpGet("GetChoice")]
        public async Task<IActionResult> GetChoice(int answerID, int questionID)
        {
            var model = await GetPickAPileAsync();
            return Ok(model.Answers.FirstOrDefault(x => x.AnswerId == answerID && x.QuestionId == questionID));
        }

    }


    public class PickAPile
    {
        public Question[] Questions { get; set; }
        public Answer[] Answers { get; set; }
    }

    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionName { get; set; }
        public string QuestionDesp { get; set; }
    }

    public class Answer
    {
        public int AnswerId { get; set; }
        public string AnswerImageUrl { get; set; }
        public string AnswerName { get; set; }
        public string AnswerDesp { get; set; }
        public int QuestionId { get; set; }
    }


}
