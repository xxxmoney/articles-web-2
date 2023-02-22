
/** Shows success toast with provided toast and translation t function. */
const showSuccess = (toast, t) => {
  toast.add({severity:'success', summary: t('toast.success.title'), detail: t('toast.success.description'), life: 1500});
};

/** Shows common or validation (based on status code if present) error toast with provided toast, translation t function and error object. */
const showError = (toast, t, error) => {
  // Show validation error toast if error is validation error.
  if (error?.status === 400) {
    showValidationError(toast, t);
    return;
  }

  toast.add({severity:'error', summary: t('toast.error.title'), detail: t('toast.error.description'), life: 3000});
};

/** Shows validation error toast with provided toast and translation t function.  */
const showValidationError = (toast, t) => {
  toast.add({severity:'error', summary: t('toast.error.title'), detail: t('toast.error.validation_description'), life: 3000});
};

export { showSuccess, showError, showValidationError }