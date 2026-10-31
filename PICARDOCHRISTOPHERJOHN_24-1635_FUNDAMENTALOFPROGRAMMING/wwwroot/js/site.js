// After a submitted form, put keyboard focus on its feedback.
window.addEventListener("load", () => {
    const feedback = document.querySelector(".error-summary, .example-output");
    if (feedback) {
        feedback.focus();
    }
});
