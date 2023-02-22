const KEY = 'languageCode';
const DEFAULT_LANGUAGE = 'en';

/** Gets locale from local storage. */
function getLocale() {
    return localStorage.getItem(KEY) ?? DEFAULT_LANGUAGE;
}
/** Sets locale to local storage. */
function setLocale(locale) {
    localStorage.setItem(KEY, locale ?? DEFAULT_LANGUAGE);
}

/** Replaces url with new locale. */
const replaceUrlLanguage = (oldLocale) => {
    const replacedUrl = location.href.replace('/' + (oldLocale ?? DEFAULT_LANGUAGE), '/' + getLocale());
    window.history.replaceState(null, document.title, replacedUrl); 
};

export { getLocale, setLocale, replaceUrlLanguage }