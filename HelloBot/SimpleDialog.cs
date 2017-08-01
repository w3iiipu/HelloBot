using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloBot
{
    using System.Threading.Tasks;

    using Microsoft.Bot.Builder.Dialogs;
    using Microsoft.Bot.Connector;

    [Serializable]
    public class SimpleDialog : IDialog
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(ActivityReceivedAsync);
        }

        private async Task ActivityReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            if (activity.Text.Contains("Hello", StringComparison.OrdinalIgnoreCase))
            {
                await context.PostAsync("Hello! My name is PondBot. How can I help you?");
            }
            else if (activity.Text.Contains("Bye", StringComparison.OrdinalIgnoreCase))
            {
                await context.PostAsync("Please visit us again. Good Bye!");
            } 
            else if (activity.Text.Contains("Thank you", StringComparison.OrdinalIgnoreCase))
            {
                await context.PostAsync("You're Welcome!");
            }
            else if (activity.Text.Contains("for") || activity.Text.Contains("to see"))
            {
                if (activity.Text.Contains("Missy", StringComparison.OrdinalIgnoreCase) || activity.Text.Contains("Interview", StringComparison.OrdinalIgnoreCase))
                {
                    await context.PostAsync("I shall inform Missy of your arrival. Please take a seat in the lobby. ");
                }
                else if (activity.Text.Contains("Joe") || activity.Text.Contains("Jason") || activity.Text.Contains("Cory"))
                {
                    await context.PostAsync("Please take a seat in the lobby and he will be right down!");
                }
                else
                {
                    await context.PostAsync("Please see Sam at the first desk!");
                }
            }
            else
            {
                await context.PostAsync("Sorry but my responses are limited. Please ask the right questions!");
            }

            context.Wait(ActivityReceivedAsync);
        }
    }
}