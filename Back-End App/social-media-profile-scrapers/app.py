
#importing the flask Module
import json
from flask import Flask
from twitter import Twitter
from instagram import Instagram
from facebook import Facebook
from github import Github
from pinterest import Pinterest
from quora import Quora
from reddit import Reddit

# Flask constructor takes the name of
# current module (__name__) as argument
app = Flask(__name__)
 
@app.route('/')
# ‘/’ URL is bound with hello_world() function.
def home():
    return """ <h2>Welcome to the Back-End API</h2>
    <br>
    <h3>Make Request to endpoints as such to get a response:</h3>
    <br><br> /twitter/username | Example: /twitter/barackObama
    <br><br> /instagram/username | Example: /instagram/the._andrew
    <br><br> /github/username | Example: /github/fabpot
    <br><br> /facebook/username | Example: /facebook/umangandrew.francis
    <br><br> /pinterest/username | Example: /pinterest/ohjoy
    """
 
@app.route('/twitter/<username>')
def twitter(username):
    resp = Twitter.scrap(username,"chrome")
    return str(resp)
 
@app.route('/instagram/<username>')
def instagram(username):
    resp = Instagram.scrap(username,"chrome")
    return str(resp)

@app.route('/facebook/<username>')
def facebook(username):
    resp = Facebook.scrap(username,"chrome")
    return str(resp)

@app.route('/github/<username>')
def github(username):
    resp = Github.scrap(username,"chrome")
    return str(resp)

@app.route('/pinterest/<username>')
def pinterest(username):
    resp = Pinterest.scrap(username)
    return str(resp)

@app.route('/quora/<username>')
def quora(username):
    resp = Quora.scrap(username,"chrome")
    return str(resp)

@app.route('/reddit/<username>')
def reddit(username):
    resp = Reddit.scrap(username,"chrome")
    return str(resp)

if __name__ == '__main__':
    app.run(host='0.0.0.0', port=5000)