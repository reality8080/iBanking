//using FirebaseAdmin;
//using FirebaseAdmin.Auth;
//using Google.Cloud.Firestore;
//using iBanking.Interfaces.Security;
//using iBanking.Models;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace iBanking.Security
//{
//    public class FirebaseAuthService: IFirebaseSer
//    {
//        private readonly FirebaseAuth _firebaseAuth;
//        private readonly FirestoreDb _db;
//        private readonly ILogger<FirebaseAuthService> _logger;

//        public FirebaseAuthService(FirebaseApp firebaseApp, FirestoreDb db, ILogger<FirebaseAuthService> logger)
//        {
//            _firebaseAuth = FirebaseAuth.GetAuth(firebaseApp??throw new ArgumentNullException(nameof(firebaseApp)));
//            _db = db ?? throw new ArgumentNullException(nameof(db));
//            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
//        }

//        public async Task<string> SignUpAsync(string username, string password, string email)
//        {
//            try
//            {
//                var userRecordArgs = new UserRecordArgs
//                {
//                    DisplayName = username,
//                    Email = email,
//                    Password = password,
//                };
//                var userRecord=await _firebaseAuth.CreateUserAsync(userRecordArgs);
//                _logger.LogInformation($"Attempting to sign up user with email:{email}");

//                var userData = new
//                {
//                    Uid = userRecord.Uid,
//                    Email=email,
//                    username = username,
//                    createAt=FieldValue.ServerTimestamp
//                };
//                await _db.Collection("users").Document(userRecord.Uid).SetAsync(userData);
//                _logger.LogInformation($"User sign up successfully: {userRecord.Uid}");
//                return userRecord.Uid;
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, $"Error signing up user with email: {email}");
//                throw;
//            }
//        }

//        public async Task<string> LogInAsync(string username, string password)
//        {
//            try
//            {

//                var query = await _db.Collection("users")
//                    .WhereEqualTo("Username", username)
//                    .Limit(1)
//                    .GetSnapshotAsync();
//                if (!query.Any())
//                {
//                    _logger.LogWarning($"Username not found: {username}");
//                    throw new Exception("Username not found");
//                }
//                _logger.LogInformation($"Attempting to sign in user with username");
//                var userDoc = query.First();
//                var email = userDoc.GetValue<string>("Email");

//                var user = await _firebaseAuth.GetUserByEmailAsync(email);
//                _logger.LogInformation($"User signed in successfully with username:{username}, UID: {user.Uid}");
//                return user.Uid;
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, $"Error signing in user with username: {username}");
//                throw;
//            }
//        }

//        public async Task sendEmailVerificationsAsync(string idToken)
//        {
//            try
//            {
//                _logger.LogInformation("Sending email verification");
//                var user = await _firebaseAuth.GetUserAsync(idToken);
//                if (!user.EmailVerified)
//                {
//                    await _firebaseAuth.GenerateEmailVerificationLinkAsync(idToken);
//                    _logger.LogInformation($"Email verification sent to: {user.Email}");
//                }
//                else
//                {
//                    _logger.LogWarning($"Email already verified for user: {user.Uid}");
//                }
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, "Error sending email verification");
//                throw;
//            }
//        }

//        public async Task<bool> isEmailVerificationsAsync(string idToken)
//        {
//            try
//            {
//                _logger.LogInformation($"Checking email verification for user: {idToken}");
//                var user = await _firebaseAuth.GetUserAsync(idToken);
//                var isVerified = user.EmailVerified;
//                _logger.LogInformation($"Email verification status: {isVerified}");
//                return isVerified;
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, $"Error checking email verification for user: {idToken}");
//                throw;
//            }
//        }

//        public async Task<string> signInWithGGAsync(string idToken)
//        {
//            try
//            {
//                _logger.LogInformation("Attempting Google sign-in");
//                var user = await _firebaseAuth.GetUserAsync(idToken);

//                var userDoc = await _db.Collection("users").Document(user.Uid)
//                    .GetSnapshotAsync();
//                if (!userDoc.Exists)
//                {
//                    var userData = new
//                    {
//                        Uid = user.Uid,
//                        Email = user.Email,
//                        Username = user.DisplayName ?? "GoogleUser",
//                        CreatedAt = FieldValue.ServerTimestamp
//                    };
//                    await _db.Collection("users").Document(user.Uid).SetAsync(userData);
//                }
//                _logger.LogInformation($"Google sign-in successfully: {user.Uid}");
//                return user.Uid;
//            }
//            catch(Exception ex)
//            {
//                _logger.LogError(ex, "Error during Google sign-in");
//                throw;
//            }
//        }

//        public async Task<Customer> getCusInfoAsync(string idToken)
//        {
//            try
//            {
//                _logger.LogInformation($"Retrieving user info for : {idToken}");
//                var user = await _firebaseAuth.GetUserAsync(idToken);
//                var Cus = new Customer
//                {
//                    idCus = user.Uid,
//                    email = user.Email,
//                    username = user.DisplayName ?? "",
//                };
//                _logger.LogInformation($"User info retrieved: {user.Uid}");
//                return Cus;
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, $"Erroe retrieving usere info for: {idToken}");
//                throw;
//            }
//        }

//        public async Task<string> LogInWithEmailAsync(string email, string password)
//        {
//            try
//            {
//                _logger.LogInformation($"Attempting to sign in user with email: {email}");
//                var user =await _firebaseAuth.GetUserByEmailAsync(email);
//                _logger.LogInformation($"User signed in successfully: {user.Uid}");
//                return user.Uid;
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, $"Error signing in user with email: {email}");
//                throw;
//            }
//        }
//    }
//}
