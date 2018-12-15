<template>
  <div class="userEdit">
    <form  style ="margin-top:20px">

      <div class="form-group">
        <h1 class="h3 mb-3 font-weight-normal">Edycja danych</h1>
        <label for="login">Login</label>
        <input type="text" class="form-control" id="loginSU" placeholder="login">
  </div>
 

      <div class="form-row">
        <div class="form-group col-md-6">
          <label for="name">Imię</label>
          <input type="text" class="form-control" id="nameSU" placeholder="imię">
    </div>
        <div class="form-group col-md-6">
          <label for="lastname">Nazwisko</label>
          <input type="text" class="form-control" id="lastnameSU" placeholder="nazwisko">
    </div>
      </div>
      <label for="deegres">Stopień naukowy</label>
      </br>
      <div class="form-check form-check-inline">
        <input class="form-check-input" type="checkbox" id="degree1" value="inz">
          <label class="form-check-label" for="degree1">inż.</label>
        </div>
      <div class="form-check form-check-inline">
        <input class="form-check-input" type="checkbox" id="degree2" value="mgr">
          <label class="form-check-label" for="degree2">mgr</label>
        </div>
      <div class="form-check form-check-inline">
        <input class="form-check-input" type="checkbox" id="degree3" value="dr">
          <label class="form-check-label" for="degree3">dr </label>
        </div>
      <div class="form-check form-check-inline">
        <input class="form-check-input" type="checkbox" id="degree4" value="dr hab">
          <label class="form-check-label" for="degree4">dr hab. </label>
        </div>

      <div class="form-check form-check-inline">
        <input class="form-check-input" type="checkbox" id="degree5" value="prof">
          <label class="form-check-label" for="degree5">prof. </label>
        </div>

      <div class="form-group">
        <label for="emailSU">Email</label>
        <input type="email" class="form-control" id="emailSU" placeholder="email">
  </div>

      <div class="form-row">
        <div class="form-group col-md-6">
          <label for="phoneSU">Telefon</label>
          <input type="text" class="form-control" id="phoneSU" placeholder="telefon">
    </div>
        <div class="form-group col-md-6">
          <label for="faxSU">FAX</label>
          <input type="text" class="form-control" id="faxSU" placeholder="fax">
    </div>
      </div>


      <button type="submit" class="btn btn-lg btn-primary btn-block">Edytuj dane</button>
    </form>
	
  </div>
</template>

<script>
  export default {
  name: 'UserEdit',
  data(){
  return{}
  }
  };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped="">
</style>
