<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet
  version="1.0"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  xmlns:msxsl="urn:schemas-microsoft-com:xslt"
  exclude-result-prefixes="msxsl"
  xmlns:myUtils="pda:MyUtils">

  <xsl:output method="xml" indent="yes"/>

  <xsl:variable name="vQ">Mr. </xsl:variable>

  <xsl:template match="@*|node()">
    <xsl:copy>
      <xsl:apply-templates select="@*|node()"/>
    </xsl:copy>
  </xsl:template>

  <xsl:template match="employee/firstname">
    <xsl:element name="firstname">
      <xsl:value-of select="myUtils:FormatName(.)" />
    </xsl:element>
    <xsl:element name="new-firstname">
      <xsl:copy-of select="myUtils:CreateNode(.)"/>
    </xsl:element>
  </xsl:template>
</xsl:stylesheet>