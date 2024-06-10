﻿using FluentValidation;

namespace LXP.Common.DTO
{
    public class UpdateQuizViewModelValidator : AbstractValidator<UpdateQuizViewModel>
    {
        public UpdateQuizViewModelValidator()
        {
            RuleFor(quiz => quiz.NameOfQuiz)
                .NotEmpty().WithMessage("Name of the quiz is required.");

            RuleFor(quiz => quiz.Duration)
                .GreaterThan(0).WithMessage("Duration must be a positive value.");

            RuleFor(quiz => quiz.PassMark)
                .GreaterThan(0).WithMessage("Pass mark must be a positive value.");

            RuleFor(quiz => quiz.AttemptsAllowed)
                .GreaterThan(0).When(quiz => quiz.AttemptsAllowed.HasValue).WithMessage("Attempts allowed must be a positive value if provided.");
        }
    }
}
