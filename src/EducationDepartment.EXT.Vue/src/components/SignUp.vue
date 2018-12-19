<template>
  <div class="signUp" style="margin-top:50px">

    <Alert v-if="alert" v-bind:message="alert" />
    <h1 class="h3 mb-3 font-weight-normal">Rejestracja</h1>
    <form v-on:submit="createAccount">
      <div class="form-group">

        <label for="login">Login</label>
        <input type="text" class="form-control" placeholder="login" v-model="account.login">
  </div>
      <div class="form-group">
        <label for="password">Hasło</label>
        <input type="password" class="form-control" placeholder="hasło" v-model="account.password">
  </div>

      <div class="form-group">
        <label for="passwordSUrepet">Powtórz hasło</label>
        <input type="password" class="form-control"   placeholder="powtórzone hasło" v-model="account.passwordRepeat">
  </div>

      <div class="form-row">
        <div class="form-group col-md-6">
          <label for="name">Imię</label>
          <input type="text" class="form-control"   placeholder="imię" v-model="account.firstname">
    </div>
        <div class="form-group col-md-6">
          <label for="lastname">Nazwisko</label>
          <input type="text" class="form-control"  placeholder="nazwisko" v-model="account.lastname">
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
        <input type="email" class="form-control"   placeholder="email" v-model="account.email">
  </div>

      <div class="form-row">
        <div class="form-group col-md-6">
          <label for="phoneSU">Telefon</label>
          <input type="text" class="form-control"   placeholder="telefon" v-model="account.phone">
    </div>
        <div class="form-group col-md-6">
          <label for="faxSU">FAX</label>
          <input type="text" class="form-control"   placeholder="fax" v-model="account.fax">
    </div>
      </div>


      <button type="submit" class="btn btn-lg btn-primary btn-block">Załóż konto</button>
    </form>


  </div>
</template>

<script>
  import Alert from "./Alert"
  export default {
  name: "SingUp",
  data() {
  return {
  account: {},
  alert: ""
  }
  },
  methods: {
  createAccount(e) {
  if (
  !this.account.login ||
  !this.account.password ||
  !this.account.passwordRepeat ||
  !this.account.email ||
  !this.account.firstname ||
  !this.account.lastname
  ) {
  this.alert = "Wypełnij wszystkie wymagane pola";
  } else
  if(this.account.login.length >15){
  this.alert = "Za długi login";
  } else
  if(this.account.firstname.length >30){
  this.alert = "Za długie imię";
  } else
  if(this.account.lastname.length >50){
  this.alert = "Za długie nazwisko";
  } else
  if(this.account.email.length >30){
  this.alert = "Za długi email";
  } else
  if(this.account.phone.length >10){
  this.alert = "Za długi nr telefonu";
  } else
  if(this.account.fax.length >10){
  this.alert = "Za długi FAX";
  } else
  {
  let newAccount = {
  firstName: this.account.firstname,
  lastName: this.account.lastname,
  email: this.account.email,
  userName: this.account.login,
  password: this.account.password
  }
  this.$http.post('https://localhost:44335//api/Accounts', newAccount)
  .then(function(response){
  this.$router.push({path: '/', query: {alert: 'Konto utworzone'}});
  });

  e.preventDefault();
  }
  e.preventDefault();
  }
  },
  components: {
  Alert
  }
  };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped="">
</style>
