class LocalUserHelper {
  static #KEY = 'user';

  /** Gets user from local storage. */
  static getUser() {
      return JSON.parse(localStorage.getItem(this.#KEY));
  }
  /** Sets user to local storage. */
  static setUser(user) {
      localStorage.setItem(this.#KEY, JSON.stringify(user));
  }
  /** Deletes user from local storage. */
  static deleteUser() {
      localStorage.removeItem(this.#KEY);
  }
}

export { LocalUserHelper }