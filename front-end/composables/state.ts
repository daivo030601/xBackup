export const state = reactive({
    isLogined : useLocalStorage("login", false),
    token: useLocalStorage("token", ""),
    tokenExpired: useLocalStorage("tokenExpired", 0),
    userEmail: useLocalStorage("userEmail", "")
})