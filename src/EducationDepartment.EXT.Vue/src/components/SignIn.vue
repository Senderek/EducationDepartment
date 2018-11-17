<template>
  <div class="singIn">
    <div class="text-center">
       
      <form class="form-signin">

        <h1 class="h3 mb-3 font-weight-normal">Zaloguj się</h1>
        <label for="inputLogin" class="sr-only">login</label>
        <input type="login" id="inputLogin" class="form-control" placeholder="login" required="" autofocus="">
          <label for="inputPassword" class="sr-only">Password</label>
          <input type="password" id="inputPassword" class="form-control" placeholder="hasło" required="">
            <div class="checkbox mb-3">
              <label>
                <input type="checkbox" value="remember-me"> Zapamiętaj 
        </label>
            </div>
            <button class="btn btn-lg btn-primary btn-block" type="submit">Zaloguj się</button>
             
          </form>
      
    </div>
  </div>
</template>

<script>
  export default {
  name: 'SignIn',
  data(){
  return{}
  }
  };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped="">
  .form-signin {
  width: 100%;
  max-width: 330px;
  padding: 50px;
  margin-left: 400px;
  }
  .form-signin .checkbox {
  font-weight: 400;
  }
  .form-signin .form-control {
  position: relative;
  box-sizing: border-box;
  height: auto;
  padding: 10px;
  font-size: 16px;
  }
  .form-signin .form-control:focus {
  z-index: 2;
  }
  .form-signin input[type="email"] {
  margin-bottom: -1px;
  border-bottom-right-radius: 0;
  border-bottom-left-radius: 0;
  }
  .form-signin input[type="password"] {
  margin-bottom: 10px;
  border-top-left-radius: 0;
  border-top-right-radius: 0;
  }
</style>
