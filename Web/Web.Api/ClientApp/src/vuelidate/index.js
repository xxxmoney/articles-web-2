import * as validators from '@vuelidate/validators'
import i18n from "../i18n"

const { createI18nMessage } = validators

const withI18nMessage = createI18nMessage({ t: i18n.global.t.bind(i18n) });

const required = withI18nMessage(validators.required);
const requiredIf = withI18nMessage(validators.requiredIf, { withArguments: true });
const email = withI18nMessage(validators.email);
/** Function that creates an is equal validation. ToMatchFunc is a function that should return value that should be matched with target value to validation to pass. */
const createIsEqual = (toMatchFunc) => validators.helpers.withMessage(i18n.global.t('validations.is_equal'), (value) => toMatchFunc() == value);

export { required, requiredIf, email, createIsEqual }