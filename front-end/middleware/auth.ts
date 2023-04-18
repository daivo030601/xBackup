
export default defineNuxtRouteMiddleware(() => {
    console.log("token", state.token,"token Expired", state.tokenExpired, "isLogined", state.isLogined,"email", state.userEmail)
    if(isTokenExpired()){
        state.token=""
    }
    if (isAuthenticated()===false) {
        return navigateTo("/");
    }
  })
  
function isAuthenticated(){
    return state.isLogined;
}
function isTokenExpired(){
    const timeToken = state.tokenExpired as number;
    const timeNow = new Date().getTime();
    if(timeToken <timeNow) return true;
    return false;
}