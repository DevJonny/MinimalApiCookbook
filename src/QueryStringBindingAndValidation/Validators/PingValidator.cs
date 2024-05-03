using FluentValidation;

public class PingValidator : AbstractValidator<Ping>
{
    public PingValidator()
    {
        RuleFor(ping => ping.Message)
            .Cascade(CascadeMode.Continue)
            .NotEmpty().WithMessage("Message is required")
            .MinimumLength(5).WithMessage("Message must be at least 5 characters");
        
        RuleFor(ping => ping.AmountString)
            .Cascade(CascadeMode.Continue)
            .Must(x => decimal.TryParse(x, out var val) && val > 0)
            .WithMessage("AmountString must be a decimal greater than 0");
    }
}