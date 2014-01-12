# CSS Presentation

## Exercise 1
Create the following web page:
* Fonts used: **Consolas, Edwardian Script ITC**
* Color: **#0094ff**

![Screenshot](https://github.com/flextry/Telerik-Academy/blob/master/Web%20Design%20&%20Development/2.%20CSS%20Styling/02.%20CSS%20-%20Presentation/01.%20Blue%20web-page/index.png?raw=true)

## Exercise 2
You are given prewritten HTML, CSS code and images. Expand the code to make the web page look exactly like the image:

![Screenshot](https://github.com/flextry/Telerik-Academy/blob/master/Web%20Design%20&%20Development/2.%20CSS%20Styling/02.%20CSS%20-%20Presentation/02.%20Styled%20web-page/index.png?raw=true)

![Sample Logo](https://github.com/flextry/Telerik-Academy/blob/master/Web%20Design%20&%20Development/2.%20CSS%20Styling/02.%20CSS%20-%20Presentation/02.%20Styled%20web-page/images/Sample%20Logo.png?raw=true)

![Li dot](https://github.com/flextry/Telerik-Academy/blob/master/Web%20Design%20&%20Development/2.%20CSS%20Styling/02.%20CSS%20-%20Presentation/02.%20Styled%20web-page/images/li-dot.png?raw=true)

```html
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>CSS Styling </title>
    <link href="2.%20homework.css" rel="stylesheet" />
</head>
<body>
    <header>
        <div id="header-container">
            <div id="logo-container">
                <h1>
                    <a href="#">
                        <img src="images/Sample%20Logo.png" />
                    </a>
                </h1>
            </div>
            <div id="reg-form-container">
                <form>
                    <div>
                        <label for="tb-username">Username: </label>
                        <input type="text" id="tb-username" name="tb-username"/><br />
                        <label for="tb-password">Password: </label>
                        <input type="password" id="tb-password" name="tb-password"/>
                    </div>
                    <button id="btn-register">Register</button>
                </form>
            </div>
        </div>
        <nav>
            <ul id="main-nav-list"  class="nav-list">
                <li>
                    <a href="#">Home</a>
                </li>
                <li>
                    <a href="#">Presentations</a>
                    <ul class="nav-list sub-nav-list">
                        <li class="selected">
                            <a href="#">Intro CSS Styling Course</a>
                        </li>
                        <li>
                            <a href="#">CSS Overview</a>
                        </li>
                        <li>
                            <a href="#">CSS Presentation</a>
                        </li>
                        <li>
                            <a href="#">CSS Display</a>
                        </li>
                        <li>
                            <a href="#">CSS Layout</a>
                        </li>
                        <li>
                            <a href="#">SASS</a>
                        </li>
                        <li>
                            <a href="#">LESS</a>
                        </li>
                    </ul>
                </li>
                <li>
                    <a href="#">Videos</a>
                </li>
                <li>
                    <a href="#">Trainers</a>
                </li>
                <li>
                    <a href="#">Contacts</a>
                </li>
            </ul>
        </nav>
    </header>
    <section>
        <article>
            <header>
                <h1>Lorem ipsum dolor sit amet</h1>
            </header>
            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin egestas, dui sed cursus placerat, felis metus sollicitudin nunc, nec venenatis augue tellus vitae nisl. Quisque ut venenatis est. Vestibulum non dolor nec sapien imperdiet semper nec quis massa. Phasellus ultrices vestibulum rutrum. Vestibulum auctor felis eget ipsum semper vulputate. Sed congue, metus sit amet tempus pretium, nunc sapien pellentesque elit, ut porttitor eros orci nec arcu. Nunc lobortis risus eget eros viverra dapibus.</p>
            <footer>
                <p>
                    published by
                    <a href="#">Doncho Minkov</a> on
                    <time>08-jan-2013</time> at
                    <time>14:51</time>
                </p>
            </footer>
        </article>
        <article>
            <header>
                <h1>Vestibulum ante ipsum primis</h1>
            </header>
            <p>Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Vivamus eget tincidunt velit. Cras sed lectus mauris. Vivamus massa lacus, laoreet nec sollicitudin eu, pharetra sed elit. Aenean quis enim dui, sed mollis sapien. Duis vel eros sapien, sed blandit magna. Praesent a dolor leo, a gravida lectus. Fusce non aliquam nibh. Aenean nisl dui, faucibus consequat fermentum at, rutrum congue urna. Ut fringilla tempor risus dictum aliquam. Donec congue sapien et massa sagittis eget pharetra risus sollicitudin. Vestibulum urna nunc, feugiat sed tincidunt et, fringilla non nisi. Mauris neque tellus, lobortis a vehicula eget, volutpat id erat. Donec rutrum consectetur malesuada. Curabitur mollis orci at sapien tristique ac mattis nulla sollicitudin.</p>
            <footer>
                <p>
                    published by
                    <a href="#">Doncho Minkov</a> on
                    <time>08-jan-2013</time> at
                    <time>14:51</time>
                </p>
            </footer>
        </article>
        <article>
            <header>
                <h1>Nullam ullamcorper dolor sed enim venenatis aliquet</h1>
            </header>
            <p>Nullam ullamcorper dolor sed enim venenatis aliquet. Aenean magna magna, consectetur vel gravida at, gravida ac eros. Donec tincidunt iaculis diam, sit amet aliquam libero fermentum non. Donec at lectus at eros interdum lobortis nec sed massa. Sed nec hendrerit magna. Nunc nec vestibulum lorem. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Pellentesque rutrum neque orci, quis dapibus justo. Sed id turpis a purus luctus dictum eget vitae tortor. Maecenas eu nunc in nisi interdum eleifend non sed ante. Integer sit amet rutrum magna. Maecenas sed blandit quam.    </p>
            <footer>
                <p>
                    published by
                    <a href="#">Doncho Minkov</a> on
                    <time>08-jan-2013</time> at
                    <time>14:51</time>
                </p>
            </footer>
        </article>
    </section>

    <aside>
        <ul>
            <li>
                <h2>Widget</h2>
                <p>
                    Duis vel eros sapien, sed blandit magna.
                    <a href="#">Praesent</a> a dolor leo, a gravida <strong>lectus</strong>. Fusce non aliquam nibh. Aenean nisl dui, faucibus consequat fermentum at, rutrum congue urna.
                </p>
            </li>
            <li>
                <h2>Widget</h2>
                <ul>
                    <li>
                        Widget Item
                    </li>
                    <li>
                        Widget Item
                    </li>
                    <li>
                        Widget Item
                    </li>
                    <li>
                        Widget Item
                    </li>
                </ul>
            </li>
            <li>
                <h2>Widget</h2>
                <p>
                    Duis vel eros sapien, sed blandit magna.
                    <a href="#">Praesent</a> a dolor leo, a gravida <strong>lectus</strong>. Fusce non aliquam nibh. <em>Aenean nisl dui</em>, faucibus consequat fermentum at, rutrum congue urna.
                </p>
            </li>
        </ul>
    </aside>
    <footer>
        <p>
            Telerik Software Academy
        </p>
    </footer>
</body>
</html>
```

```css
.clearfix, body header div#header-container, body header nav, body header nav ul, body header nav ul li ul.sub-nav-list, body section, body aside {
    zoom: 1;
}

    .clearfix:after, body header div#header-container:after, body header nav:after, body header nav ul:after, body header nav ul li ul.sub-nav-list:after, body section:after, body aside:after, .clearfix:before, body header div#header-container:before, body header nav:before, body header nav ul:before, body header nav ul li ul.sub-nav-list:before, body section:before, body aside:before {
        content: "\0020";
        display: block;
        height: 0;
        overflow: hidden;
    }

    .clearfix:after, body header div#header-container:after, body header nav:after, body header nav ul:after, body header nav ul li ul.sub-nav-list:after, body section:after, body aside:after {
        clear: both;
    }

body, header, section, footer, article, h1, h2, h3, h4, h5, h6, input, button, label, p, fieldset, nav, ul, li, a, span, strong, em {
    margin: 0;
    padding: 0;
    border: 0;
}

div, h1, h3, h4, h5, h6, header, footer, body, section, nav, article, aside {
    display: block;
}

body {
    font: 14px normal Arial;
    color: white;
}

    body header {
        padding-top: 25px;
        padding-bottom: 5px;
        padding-right: 15px;
        padding-left: 15px;
    }

        body header div#header-container div#logo-container {
            float: left;
            position: relative;
        }

        body header div#header-container div#reg-form-container {
            float: right;
            position: relative;
            right: 5%;
            top: 50%;
        }

            body header div#header-container div#reg-form-container div {
                text-align: right;
            }

                body header div#header-container div#reg-form-container div label {
                    width: 50px;
                    margin: 5px;
                }

                body header div#header-container div#reg-form-container div input {
                    width: 130px;
                    border: 1px solid #603382;
                    border-radius: 10px;
                    padding: 2px 5px;
                    margin: 5px;
                }

            body header div#header-container div#reg-form-container button {
                margin-left: auto;
                margin-right: auto;
                font-weight: bold;
                border: 1px solid #603382;
                border-style: outset;
                border-radius: 10px;
                padding: 5px 8px;
            }

                body header div#header-container div#reg-form-container button:hover {
                    background-color: #8949b9;
                    border-style: inset;
                }

        body header nav {
            display: inline-block;
            width: 75%;
            margin: 20px 20px 20px 20px;
            padding: 12px;
            border: 2px solid #000;
        }

            body header nav ul.nav-list {
                list-style-type: none;
            }

            body header nav ul li {
                float: left;
                margin: 0;
            }

                body header nav ul li a {
                    text-decoration: none;
                    padding: 0 10px 0 10px;
                    color: white;
                    font: 1.4em normal Arial;
                }

                    body header nav ul li a.selected {
                        font-weight: bold;
                    }

                body header nav ul li:hover > a {
                    text-decoration: underline;
                    color: #a8a8a8;
                }

                    body header nav ul li:hover > a + ul {
                        display: block;
                    }

                body header nav ul li ul.sub-nav-list {
                    position: absolute;
                    display: none;
                    background-color: rgba(179, 94, 243, 0.9);
                    border-radius: 5px;
                }

                body header nav ul li ul li {
                    float: none;
                    margin: 0 15px;
                    padding: 10px 0;
                    border-bottom: 1px solid black;
                }

                    body header nav ul li ul li:last-of-type {
                        border-bottom: none;
                    }

                    body header nav ul li ul li > a {
                        font-size: 1.2em;
                        color: #fff;
                    }

    body section {
        width: 75%;
        float: left;
        color: black;
    }

        body section article {
            margin: 20px;
            padding: 20px;
            border: 1px solid black;
        }

            body section article header {
                background: none;
                padding: 5px;
            }

                body section article header h1 {
                    font-size: 1.4em;
                    padding: 0;
                }

            body section article footer {
                padding: 5px;
            }

                body section article footer p {
                    font-size: 16px;
                    text-align: right;
                    font-weight: normal;
                }

                    body section article footer p time {
                        font-family: Consolas, 'Lucida Console', 'DejaVu Sans Mono', monospace;
                    }

                    body section article footer p a {
                        text-decoration: none;
                    }

                        body section article footer p a:hover {
                            text-decoration: underline;
                        }

    body aside {
        float: left;
        width: 20%;
        margin: 20px;
    }

        body aside > ul {
            list-style-type: none;
        }

            body aside > ul > li {
                margin: 15px 0;
                padding: 15px;
                border: 1px solid black;
                border-radius: 5px;
            }

                body aside > ul > li h2 {
                    font-size: 1.1em;
                    font-weight: bold;
                }

                body aside > ul > li p {
                    margin-top: 10px;
                    margin-right: 5px;
                    margin-bottom: 10px;
                    margin-left: 5px;
                    font-size: 14px;
                }

                    body aside > ul > li p a {
                        color: #aaaaaa;
                        text-decoration: none;
                    }

                    body aside > ul > li p strong {
                        color: #cccccc;
                        font-weight: bold;
                        font-style: normal;
                    }

                    body aside > ul > li p em {
                        color: #cccccc;
                        font-weight: normal;
                        font-style: italic;
                    }

                body aside > ul > li ul {
                    list-style-type: none;
                    margin-top: 10px;
                    margin-right: 0;
                    margin-bottom: 10px;
                    margin-left: 0px;
                }

                    body aside > ul > li ul li {
                        margin-top: 5px;
                        margin-left: 10px;
                        margin-bottom: 0px;
                        margin-right: 0px;
                        background: url(images/li-dot.png) no-repeat;
                        background-position: 0 50%;
                        padding-left: 25px;
                    }

    body footer {
        clear: both;
        padding-top: 15px;
        padding-bottom: 25px;
        padding-right: 0px;
        padding-left: 0px;
    }

        body footer p {
            font-size: 1.2em;
            font-weight: bold;
        }
```

## Exercise 3
Create the following web page:
* Using 60 nested div elements

![Screenshot](https://github.com/flextry/Telerik-Academy/blob/master/Web%20Design%20&%20Development/2.%20CSS%20Styling/02.%20CSS%20-%20Presentation/03.%20Nested%20divs/index.png?raw=true)

## Exercise 4
Create a web page that looks like the Windows calculator in Programmer view:
* It should look **exactly** the same
* Implement **hover** effects for the buttons
* The calculator should not have **any functionality**

![Screenshot](https://github.com/flextry/Telerik-Academy/blob/master/Web%20Design%20&%20Development/2.%20CSS%20Styling/02.%20CSS%20-%20Presentation/04.%20Windows%20Calculator/index.png?raw=true)
