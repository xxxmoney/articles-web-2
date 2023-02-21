
/** Shows success toast with provided toast and translation t function. */
const showSuccess = (toast, t) => {
  toast.add({severity:'success', summary: t('toast.success.title'), detail: t('toast.success.description'), life: 1500});
};

/** Shows error toast with provided toast and translation t function. */
const showError = (toast, t) => {
  toast.add({severity:'error', summary: t('toast.error.title'), detail: t('toast.error.description'), life: 3000});
};

export { showSuccess, showError }