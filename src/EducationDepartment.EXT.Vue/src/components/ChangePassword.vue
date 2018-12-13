<template>
  <div class="changePassword">

   <form  style ="margin-top:20px">

      <div class="form-group">
        <h1 class="h3 mb-3 font-weight-normal">Zmień hasło</h1>
        <label for="passwrod">Stare hasło</label>
        <input type="password" class="form-control" id="oldPassword" placeholder="stare hasło">
  </div>
      <div class="form-group">
        <label for="newpassword">Nowe hasło</label>
        <input type="password" class="form-control" id="password" placeholder="nowe hasło">
  </div>

      <div class="form-group">
        <label for="newPasswordRepeat">Powtórz nowe hasło</label>
        <input type="password" class="form-control" id="newPasswordSUrepet" placeholder="powtórzone nowe hasło">
  </div>

       
         
      
 

      
      
       
      <button type="submit" class="btn btn-lg btn-primary btn-block">Zmień hasło</button>
    </form>
    

  </div>
</template>

<script>
  export default {
  name: 'ChangePassword',
  data(){
  return{}
  }
  };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped="">
</style>
